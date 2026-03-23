## Uruchamianie
#### Standardowe
```shell
    dotnet run --console --project APBD_cw2_project_s27023
```
#### Testowe komendy
```shell
    dotnet run --console --test --project APBD_cw2_project_s27023
```
## Decyzje
Inspiracje czerpię z architektury Spring boot.

- Modele/Entities - Najprostrze reprezentacjie podstawowych objektów takich jak użytkownik, wypożyczenie czy sprzęt, zawierają zero lub bardzo mało logiki. Ich najważniejszym celem jest przechowywanie danych.
- Services - Klasy zawierające logikę biznesową.
- Factories - Klasy zawierające pomocnicze metody tworzące Modeles

## Kohezja
Każdy serwis odpowiada tylko i wyłącznie za swoje modele.

 - `UserService` Odpowiada za proste operacje CRUD na użytkownikach
 - `EquipmentService` Odpowiada za proste operacje CRUD na sprzęcie
 - `RentService` Udostępnia proste operacje CRUD dla wyprorzyczeń, ale także dba o logikę biznesową związaną z wypożyczaniem sprzętu.
 - `AvailabilityService` Logika sprawdzania czy sprzęt jest dostępny nie pasowała do żadnego innego serwisu, została wydzielona do swojego własnego
 - `ServicingService` Podstawowe operacje CRUD dla serwisowania sprzętu.

## Coupling
Serwisy komunikują się między sobą oraz innymi elementami systemu poprzez interfejsu.
W razie dowolniej potrzeby np testowania, możemy utworzyć nową lekką klasę serwisową z dummy serwisami.