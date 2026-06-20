TaskManagementMVC – System zarządzania zadaniami dla zespołu programistycznego

Spis treści:
1. Funkcjonalności
2. Wymagane pakiety
3. Instrukcja uruchomienia

1. Funkcjonalności
    - Zarządzanie zadaniami
        Zalogowany użytkownik może dodawać, edytować, przeglądać i usuwać zadania.

    - Zarządzanie projektami
        Zalogowany użytkownik może dodawać, edytować i usuwać projekty.

    - Zarządzanie użytkownikami
        Możliwość rejestracji kont, logowania i wylogowania użytkowników.

    - Logika sesji użytkownika
        Dostęp do wybranych funkcji aplikacji wymaga zalogowania użytkownika.

    - Zarządzanie statusami i priorytetami
        Zadania posiadają status (Todo, InProgress, Done) oraz priorytet.

    - Zarządzanie terminami wykonania
        Zadania posiadają termin realizacji, który podlega walidacji.

    - Przypisywanie użytkowników i projektów
        Zadania mogą być przypisywane do konkretnych użytkowników i projektów.

    - Wyszukiwanie i filtrowanie
        Możliwość wyszukiwania zadań po tytule oraz filtrowania ich po statusie.

    - Walidacja danych
        Formularze sprawdzają poprawność wprowadzanych danych (wymagane pola, długość tekstu, format e-mail, zgodność haseł, poprawność dat).

    - Testy jednostkowe
        Projekt zawiera przykładowe testy jednostkowe sprawdzające poprawność zaimplementowanych funkcjonalności.

2. Wymagane pakiety
    Pakiety można zainstalować przy pomocy menedżera NuGet w programie Visual Studio:
    Tools → NuGet Package Manager → Manage NuGet Packages for Solution

    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.AspNetCore.Session
    - xUnit
    - xUnit.runner.visualstudio
    - Microsoft.NET.Test.Sdk

3. Instrukcja uruchomienia
    - Pobrać repozytorium z serwisu GitHub lub otworzyć projekt w programie Visual Studio.
    - Zainstalować wymagane pakiety: Tools → NuGet Package Manager → Manage NuGet Packages for Solution.
    - W Package Manager Console wykonać polecenie: Update-Database
    - Uruchomić aplikację