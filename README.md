# Uruchamianie
```shell
    dotnet run APBD_cw2_project_s27023/cli/Cli.cs
```
# Decyzje
Inspiracje czerpię z architektury Spring boot.

- Modele/Entities - Najprostrze reprezentacjie podstawowych objektów takich jak użytkownik, wypożyczenie czy sprzęt, zawierają zero lub bardzo mało logiki. Ich najważniejszym celem jest przechowywanie danych.
- Services - Klasy zawierające logikę biznesową.
- Factories - Klasy zawierające pomocnicze metody tworzące Modeles