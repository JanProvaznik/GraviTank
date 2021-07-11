# GraviTank (EN)


# GraviTank (CZ)
- Zápočtový program 
- NPRG031 Programování 2
- Červenec 2021
- Použitá verze enginu: Unity 2020.3.13f1

## Zadání a úvod
Je to hra pro dva hráče v enginu Unity. Účelem hry je zábava. Nápad vznikl vzpomínáním na flashové hry, které jsem hrál v letech základní školy na internetu se sestrou. Nejužší inspirací jsou [Tanks od 2dplay.com](https://archive.org/details/tanks_flashgame), později mi došlo, že je hra podobná také [Worms](https://cs.wikipedia.org/wiki/Worms_(hern%C3%AD_s%C3%A9rie)). Hlavní "ozvláštňující myšlenka" je souboj na kruhové planetě s gravitací. 
Velkou výhodou i nevýhodou Unity je, že spousta práce se děje v hezkém GUI, tím pádem není nutné psát tolik kódu, ale zato se lze snáze ztratit v bezedných klikátkách.
Vše kromě tohoto dokumentu je pojmenováno anglicky, abych se mohl "chlubit" i v zahraničí. 
## Uživatelský návod
Build je díky Unity možný pro vše co má QWERT(YZ) klávesnici (Windows, Linux, Mac, WebGL). Přikládám .exe


Ovládání je vysvětleno v úvodní scéně. Cíl hry je snížit životy nepřítele na nulu. Střela ubírá životy úměrně síle výstřelu a času letu (aby se hráči snažili dělat co největší oblouky). Náraz dvou střel do sebe je obě zničí. Občas létají meteory, aby se hráči nemohli sousředit jen na míření, ale museli někdy i uhýbat. 

## Struktura
Značení: **Termíny Unity**, _Moje objekty_. Nebylo by užitečné všechny Termíny Unity zde vysvětlovat, takže odkazuji na [dokumentaci](https://docs.unity3d.com/Manual/index.html).

Hra v Unity se skládá ze **Scene**s, které obsahují **GameObject**y s **Component**ami, Snažil jsem se co nejvíce vlastností umístit do **Prefab**ů, ale některé jsem specifikoval jen individuálně (klávesy ovládání).
### Scény
#### WelcomeScene
Obsahuje vypsané ovládání, tlačítko na začátek hry a textboxy na jména.
#### GameScene
Zde probíhá hra.
 Obsahuje _Planetu_, 2 _Playery_, **Kameru**.
Hra skončí až jeden z hráčů nemá životy, zastaví se čas a zobrazí kdo vyhrál.
### Prefaby
#### Player
Skládá se z mnoha **GameObject**ů.
### Skripty
Skripty jsem pojal jako ucelený soubor chování daného Prefabu, takže **Prefab** _Player_ má více skriptů. Je to sice horší na výkon a přímočarost v GUI, ale lepší na orientaci v kódu.
#### GravityToPlanet
**GameObjecty**, které maji tento skript jsou přitahovány k _Planetě_ (jen jedna => jednoduché). Přitahování je řešeno působením síly na **Rigidbody2D**.
#### Movement
Pohyb _Playera_, využívá komponentu **Rigidbody2D** pro udělení síly. Protože tank je **Dynamic Rigidbody**, necháme engine spočítat umístění a rychlost ze sil, které na něj působí. Nedovolíme moc velkou rychlost, abychom neodletěli z planety.
#### Aiming
Pohyb hlavně, potřebuje znát 
#### Shooting 
#### Movement

## Závěr
Tvorbu jsem si užil a myslím, že jsem lépe připraven účastnit se v budoucnu nějakého Game Jamu se schopností vyznat se, ve všech možných relativních a absolutních pozicích. Nejobtížnější je balanc fyzikálních konstant, aby byla hra zábavná. Také je těžké rozhodnout o úrovni abstrakce, kterou chci použít, protože jsem si nebyl jistý nakolik bych chtěl znovu využívat vytvořené Prefaby a Skripty.
### Co by šlo udělat dál
Možnost změny ovládání.
Více herních map/scén.
Změna fyzikálních vlastností za běhu.
Grafika, animace.
Lepší tvary tanků.
Umělá inteligence.