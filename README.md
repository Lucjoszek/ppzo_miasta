# PPZO - Miasta

> Zadanie wykonane w ramach przedmiotu "Podstawy programowania zorientowane obiektowo".

Prosta aplikacja webowa ASP.NET Core MVC, która pozwala użytkownikowi wybrać województwo i miasto, a następnie wyświetla współrzędne geograficzne wybranego miasta.

## Opis projektu

- Backend napisany w C# z wykorzystaniem ASP.NET Core MVC.
- Połączenie z bazą danych MS Access (`Miasta.mdb`) realizowane za pomocą ADO.NET (`System.Data.OleDb`).
- Frontend wykorzystuje HTML, CSS oraz JavaScript (fetch API) do dynamicznego pobierania i wyświetlania danych bez przeładowania strony.
- Umożliwia wybór województwa z rozwijanej listy, a następnie dynamiczne załadowanie miast z danego województwa.
- Po wyborze miasta i kliknięciu przycisku wyświetlane są długość i szerokość geograficzna.