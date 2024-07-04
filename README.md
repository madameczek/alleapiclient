# cost collector

Aplikacja pobiera koszty zamowień z allegro api.

## Zrobione

* Otworzone zadane encje z przykładowymi danymi
* Encje do zapisu
  * Płatności
  * Typy płatności - *type* z allego api
  * Kategorie płatności - koszty stałe, prowizje, inne koszty
* Pobieranie access tokena z dysku lub appsettings.json lub user-secrets
  * Klasa *TokenReader* ma zmienną *path*. Stamdtąd nastąpi próba pobrania ściągniętego tokena
* Modele danych z allegro api dla płatności powiązanych z zamówieniem i nie powiązanych
* Pobieranie danych z allegro api
  * aplikacja wypisuje pobrane dane na konsoli
* Serwisy
  * Pobieranie kategorii kosztów z appsettings
    * wskazuje jakie typy są kosztami stałymi, a jakie kosztami transakcji
  * PaymentParser - parsuje różne typy płatności. Wykorzystywany przez AllegroClient
  * AllegroClient - pobiera koszty z api
    * wszystkie
    * albo tylko powiązane z zamówieniem (parametr opcjonalny)
  * Customowe konwertery deserializatora json zwracają sparsowane dane w odpowiednich typach (kwota do decimal itd.)

## Do zrobienia

1. Encje łączące Płatność - Zamówienie i Płatność - Oferta
2. Mapery modeli dancy z allegro do encji bazodanowych
3. Repozytorium obsługujące persystencję z uwzględnieniem typu płatności
4. Serwis sklejający części składowe (np. background worker z timerem, który mógłby pobierać nowe płatności)

## Nie przewidziane
1. Testy
2. Obsługa błędów. Polityki obsługi transient I/O errors. Szczególnie błędów warstwy persystencji i nieważnego tokena
   3. Zrobienie tego pokaże sprawnie działającą aplikację, ale raczej spowoduje, że będzie ona niepotrzebnie skomplikowana  