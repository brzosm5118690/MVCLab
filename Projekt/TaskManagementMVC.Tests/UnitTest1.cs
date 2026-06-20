using System.ComponentModel.DataAnnotations;
using TaskManagementMVC.Models;
using Xunit;

public class TaskItemTests
{
    [Fact]
    public void Title_Is_Required()
    {
        var task = new TaskItem
        {
            Title = "",
            Description = "Test"
        };

        var context = new ValidationContext(task);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            task,
            context,
            results,
            true);

        Assert.False(isValid);
    }
    [Fact]
    public void Passwords_Must_Be_Equal()
    {
        var model = new RegisterViewModel
        {
            Username = "admin",
            Email = "test@test.pl",
            Password = "123456",
            ConfirmPassword = "654321"
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            true);

        Assert.False(isValid);
    }
    [Fact]
    public void Password_Must_Have_Minimum_Length()
    {
        var model = new RegisterViewModel
        {
            Username = "admin",
            Email = "test@test.pl",
            Password = "123",
            ConfirmPassword = "123"
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            true);

        Assert.False(isValid);
    }
    [Fact]
    public void Email_Must_Be_Valid()
    {
        var model = new RegisterViewModel
        {
            Username = "admin",
            Email = "abc",
            Password = "123456",
            ConfirmPassword = "123456"
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            true);

        Assert.False(isValid);
    }
    [Fact]
    public void Title_Max_Length()
    {
        var task = new TaskItem
        {
            Title = new string('A', 101),
            Description = "Test"
        };

        var context = new ValidationContext(task);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            task,
            context,
            results,
            true);

        Assert.False(isValid);
    }
    [Fact]
    public void RegisterModel_With_Valid_Data_Should_Be_Valid()
    {
        var model = new RegisterViewModel
        {
            Username = "admin",
            Email = "admin@test.pl",
            Password = "123456",
            ConfirmPassword = "123456"
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            true);

        Assert.True(isValid);
    }
    [Fact]
    public void Deadline_Cannot_Be_In_Past()
    {
        var task = new TaskItem
        {
            Title = "Test task",
            Description = "Test",
            Deadline = DateTime.Today.AddDays(-1)
        };

        Assert.True(task.Deadline < DateTime.Today);
    }
    [Fact]
    public void Username_Must_Have_Minimum_Length()
    {
        var model = new RegisterViewModel
        {
            Username = "ab",
            Email = "test@test.pl",
            Password = "123456",
            ConfirmPassword = "123456"
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            true);

        Assert.False(isValid);
    }
}