
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.Models;
using TaskManagementMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TaskItemsController : Controller
{
    private readonly ApplicationDbContext _context;

    public TaskItemsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TASKITEMS
    public async Task<IActionResult> Index(
    string searchString,
    TaskManagementMVC.Models.TaskStatus? status)
    {
        var taskItems = _context.TaskItems
            .Include(t => t.User)
            .Include(t => t.Project)
            .AsQueryable();

        // wyszukiwanie po tytule
        if (!string.IsNullOrEmpty(searchString))
        {
            taskItems = taskItems.Where(t =>
                t.Title.Contains(searchString));
        }

        // filtrowanie po statusie
        if (status.HasValue)
        {
            taskItems = taskItems.Where(t =>
                t.Status == status.Value);
        }

        ViewBag.SearchString = searchString;
        ViewBag.Status = status;

        return View(await taskItems.ToListAsync());
    }

    // GET: TASKITEMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var taskitem = await _context.TaskItems
            .Include(t => t.User)
            .Include(t => t.Project)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (taskitem == null)
        {
            return NotFound();
        }

        return View(taskitem);
    }

    // GET: TASKITEMS/Create
    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction(
                "Login",
                "Account");
        }
        ViewData["UserId"] =
            new SelectList(_context.Users, "Id", "Name");

        ViewData["ProjectId"] =
            new SelectList(_context.Projects, "Id", "Name");

        return View();
    }

    // POST: TASKITEMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,Status,Priority,Deadline,UserId,ProjectId")] TaskItem taskitem)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction(
                "Login",
                "Account");
        }
        if (taskitem.Deadline < DateTime.Today)
        {
            ModelState.AddModelError(
                "Deadline",
                "Deadline cannot be earlier than today.");
        }
        if (ModelState.IsValid)
        {
            _context.Add(taskitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["UserId"] =
            new SelectList(_context.Users,
                "Id",
                "Name",
                taskitem.UserId);
        ViewData["ProjectId"] =
            new SelectList(_context.Projects,
                "Id",
                "Name",
                taskitem.ProjectId);
        return View(taskitem);
    }

    // GET: TASKITEMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction(
                "Login",
                "Account");
        }
        if (id == null)
        {
            return NotFound();
        }

        var taskitem = await _context.TaskItems
            .Include(t => t.User)
            .Include(t => t.Project)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (taskitem == null)
        {
            return NotFound();
        }
        ViewData["UserId"] =
            new SelectList(_context.Users,
                           "Id",
                           "Name",
                           taskitem.UserId);

        ViewData["ProjectId"] =
            new SelectList(_context.Projects,
                           "Id",
                           "Name",
                           taskitem.ProjectId);
        return View(taskitem);
    }

    // POST: TASKITEMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Description,Status,Priority,Deadline,UserId,ProjectId")] TaskItem taskitem)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction(
                "Login",
                "Account");
        }
        if (id != taskitem.Id)
        {
            return NotFound();
        }
        if (taskitem.Deadline < DateTime.Today)
        {
            ModelState.AddModelError(
                "Deadline",
                "Deadline cannot be earlier than today.");
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(taskitem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(taskitem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["UserId"] =
            new SelectList(_context.Users,
                           "Id",
                           "Name",
                           taskitem.UserId);

        ViewData["ProjectId"] =
            new SelectList(_context.Projects,
                           "Id",
                           "Name",
                           taskitem.ProjectId);
        return View(taskitem);
    }

    // GET: TASKITEMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction(
                "Login",
                "Account");
        }
        if (id == null)
        {
            return NotFound();
        }

        var taskitem = await _context.TaskItems
            .Include(t => t.User)
            .Include(t => t.Project)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (taskitem == null)
        {
            return NotFound();
        }

        return View(taskitem);
    }

    // POST: TASKITEMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction(
                "Login",
                "Account");
        }
        var taskitem = await _context.TaskItems.FindAsync(id);
        if (taskitem != null)
        {
            _context.TaskItems.Remove(taskitem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TaskItemExists(int? id)
    {
        return _context.TaskItems.Any(e => e.Id == id);
    }
}
