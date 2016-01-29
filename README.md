#Projekt zaliczeniowy przedmiotu
#Komunikacja
#Człowiek
#Komputer

##Nazwa projektu: SimBot

Skład zespołu:
•	Paweł Łukasik
•	Michał Szczepanowski
•	Adam Kulczycki
•	Paweł Urbaniak

Naszym projektem zaliczeniowym jest SimBot. Nasz projekt to nic innego jak stworzony na podstawie znanej postaci BB8 , robot, który wspomaga użytkownika przy zarządzaniu mieszkaniem. Projekt został stworzony w Unity, zorientowany jest w 3D a skrypty pisane są w języku C#. Robot potrafi poruszać się pomiędzy pomieszczeniami oraz pomiędzy obiektami a także interaktować z elementami wyposażenia mieszkania. Dba o to, aby przez przypadek nie interaktować z urządzeniem, co do którego nie została wystosowana komenda, oraz aby „podwójnie” nie uruchamiać czy nie wyłączać urządzeń.
Ogólny zarys mieszkania prezentuje się następująco:

![alt tag](http://i.imgur.com/CIkEmin.png)

Potrafi on rozpoznać następujące polecenia:
•	Idź do <pomieszczenie>
•	Włącz <urządzenie>/muzykę
•	Oraz inne polecenia, które wydalibyśmy mu aby aktywować obiekty.
Robot potrafi wykonać kilka poleceń naraz, jednakże kolejne polecenia muszą być połączone „i”, „ , ” lub „oraz” np.: Idź do kuchni i włącz światło.
Obiekty, które możemy aktywować to:
•	Szafa
•	Łóżko (Pościel łóżko)
•	Pralka
•	Kuchenka
•	Wanna
•	Kran
•	Światło
•	Telewizor
•	Oraz wieża muzyczna (pod komendą włącz muzykę)
•	Światło
•	Napełnianie/opróżnianie wanny
To co udało nam się osiągnąć to efekt wspólnej pracy, której rozkład wygląda następująco:
Paweł Łukasik:
•	Rozpoznawanie mowy (własny sposób, nie wykorzystujemy aimla)
•	Ułożenie przedmiotów, dekoracja
•	Dźwięki
•	Poprawy do ruchu postaci
•	Nauka C# oraz Unity od podstaw
Adam Kulczycki:
•	„kształty” przedmiotów
•	Rozpoznawanie mowy (budowa słownika)
•	Dekoracje mieszkania
•	Poprawy do ruchu postaci
•	Nauka C# oraz Unity od podstaw
Michał Szczepanowski:
•	Dekoracje mieszkania
•	Rampy – debug nieodjeżdzania od elementów
•	Menu start, menu pause
•	Poprawki do ruchu postaci pomiędzy obiektami.
•	Nauka C# oraz Unity od podstaw
 
Paweł Urbaniak:
•	Ogólny zarys mieszkania
•	Ogólny zarys aplikacji
•	Ruch postaci pomiędzy pomieszczeniami
•	Znajdowanie obiektów
•	Nauka C# oraz Unity od podstaw

Projekt został stworzony w całości w Unity wersji 5.3.1f1 , został skompilowany pod Windows i Android, dodatkowo nie są do niego wymagane żadne biblioteki zewnętrzne.

Link do repozytorium:[Absolute README link]( https://github.com/Kaceki/SimBot-Unity )
