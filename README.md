# Uruchamianie
### Standardowe
```shell
    dotnet run --console --project APBD_cw2_project_s27023
```
### Testowe komendy
```shell
    dotnet run --console --test --project APBD_cw2_project_s27023
```
# Decyzje
Inspiracje czerpię z architektury Spring boot.

- Modele/Entities - Najprostrze reprezentacjie podstawowych objektów takich jak użytkownik, wypożyczenie czy sprzęt, zawierają zero lub bardzo mało logiki. Ich najważniejszym celem jest przechowywanie danych.
- Services - Klasy zawierające logikę biznesową.
- Factories - Klasy zawierające pomocnicze metody tworzące Modeles