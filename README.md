# cost collector

Aplikacja pobiera koszty zamowień z allegro api.

## Zrobione

* Utworzone zadane w zadaniu encje z przykładowymi danymi
* Encje do zapisu
  * Płatności
  * Typy płatności - *type* z allego api (migracje zawierają niektóre typy)
  * Kategorie płatności - koszty stałe, prowizje, inne koszty
* Pobieranie access tokena z dysku lub appsettings.json lub user-secrets
  * Klasa *TokenReader* ma zmienną *path*. Stamdtąd nastąpi próba pobrania ściągniętego tokena
* Modele danych z allegro api dla płatności powiązanych z zamówieniem i takich, które nie odnoszą się do zamówinia (np. wpłata)
* Pobieranie danych z allegro api
* Serwisy
  * *AllegroClient* - pobiera koszty z api
    * wszystkie
    * albo tylko powiązane z zamówieniem (parametr opcjonalny)
  * Jest też *AllegroService* utylizujące *AllegroClient*. 
    * W zasadzie zbędne. Wystarczy przenieść obsługę błędów do *AllegroClient* 
  * *PaymentParser* - parsuje różne typy płatności. Wykorzystywany przez *AllegroClient*
  * Customowe konwertery deserializatora json zwracają sparsowane dane w odpowiednich typach (kwota do decimal itd.)
  * Pobieranie kategorii kosztów z appsettings
    * wskazuje jakie typy są kosztami stałymi, a jakie kosztami transakcji
  * Repozytorium *PaymentRepository* (MS SQL)
    * Serwis obługujący repozytorium (w tak małej apce ta dodatkowa warstwa wydaje się zbędna, ale już jest zrobiona ;)
* Aplikacja zapisuje wynik działania do tabeli `[militaria].[dbo].[Payments]`
  * Pobierane są tylko płatności związane z istniejącym w bazie zamówieniem 
  * Nie są zapisywane duplikaty płatności przy ponownym uruchomieniu aplikacji
* Mapery modeli danych z allegro do encji bazodanowych

## Do zrobienia

* Ewentualnie serwis sklejający części składowe (np. background worker z timerem, który mógłby pobierać nowe płatności)
  * Tymczasem nie jest uruchamiana aplikacja. Ze zbudowanego hosta pobierane są potrzebne serwisy
* Jest wykonane i zasilone danymi powiązanie kategorii (np. koszty stałe) i typu płatności. Można dokończyć drugie polecenie czyli pobierać z bazy płatności o zadanej kategorii

## Nie przewidziane
1. Testy
2. Obsługa błędów. Polityki obsługi transient I/O errors. Szczególnie błędów warstwy persystencji i nieważnego tokena
   1. Zrobienie tego pokaże sprawnie działającą aplikację, ale raczej spowoduje, że będzie ona mniej czytelna

![]()