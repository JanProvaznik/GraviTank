# GraviTank (CZ)
- Zápočtový program 
- NPRG031 Programování 2
- Červenec 2021
- Použitá verze enginu: Unity 2020.3.13f1

## Zadání a úvod
Je to hra pro dva hráče v enginu Unity. Účelem hry je zábava. Nápad vznikl vzpomínáním na flashové hry, které jsem hrál v letech základní školy na internetu se sestrou. Nejužší inspirací jsou [Tanks od 2dplay.com](https://archive.org/details/tanks_flashgame), později mi došlo, že je hra podobná také [Worms](https://cs.wikipedia.org/wiki/Worms_(hern%C3%AD_s%C3%A9rie)). Hlavní "ozvláštňující myšlenka" je souboj na kruhové planetě s gravitací. 
Velkou výhodou i nevýhodou Unity je, že spousta práce se děje v hezkém GUI, tím pádem není nutné psát tolik kódu, ale zato se lze snáze ztratit v bezedných klikátkách.

## Uživatelský návod
Build je díky Unity možný pro vše co má QWERT(YZ) klávesnici (Windows, Linux, Mac, WebGL). Přikládám .exe


Ovládání je vysvětleno v úvodní scéně. Konkrétní mechaniky se nejlépe pochopí hraním. Cíl hry je snížit životy nepřítele na nulu. Střela ubírá životy úměrně síle výstřelu a času letu (aby se hráči snažili dělat co největší oblouky). Náraz dvou střel do sebe je obě zničí. Občas létají meteory, aby se hráči nemohli sousředit jen na míření, ale museli někdy i uhýbat. 

## Struktura
Značení: **Termíny Unity**, _Moje objekty_. Nebylo by užitečné všechny termíny Unity zde vysvětlovat, takže odkazuji na [dokumentaci](https://docs.unity3d.com/Manual/index.html).

Hra v Unity se skládá ze **Scene**s, které obsahují **GameObject**y s **Component**ami, Snažil jsem se co nejvíce vlastností umístit do **Prefab**ů, ale některé jsem specifikoval jen individuálně (klávesy ovládání). Skoro vše se počítá ve floatech, protože je hra "spojitá".
### Scény
#### WelcomeScene
Obsahuje vypsané ovládání, tlačítko na začátek hry a textboxy na jména hráčů.
#### GameScene
Zde probíhá hra.
 Obsahuje _Planetu_, 2 _Playery_, **Kameru**.
Hra skončí až jeden z hráčů nemá životy.

#### EndScene
Obsahuje Kameru, text kdo vyhrál a tlačítka k restartu/konci.

### Prefaby
Všechny **Prefaby** kromě _Planety_ mají skript _GravityToPlanet_.

#### Player
Má dceřinné **GameObjecty**: _Head, Barrel, HealthSlider, ShotSlider_ a spoustu komponent, které určují jeho zobrazení, fyziku a chování. Důležité jsou skripty _Health, Shooting, Aiming, Movement_, **Collider**y a **Rigidbody2D**. 

#### Planet
Má **Rigidbody2D** a **Collider**, který obsahuje **Material** s upravenou konstantou tření _LowFriction_.

#### Shot
Má **Rigidbody2D a Collider**, který má nastaveno, že je **Trigger**, takže kolize vyvolá event OnTriggerEnter(), který je obsloužen v skriptu _ShotDamage_, který _Shot_ také mění barvu podle _damage_ jaký způsobí. 

#### Meteor
Podobné _Shot_, ale _damage_ je konstantní. Generuje se náhodně v prostoru.

### Skripty
Skripty představují ucelený soubor chování daného **Prefabu** či **scény**, proto např. **Prefab** _Player_ má více skriptů.

#### GravityToPlanet
**GameObjecty**, které maji tento skript jsou přitahovány k _Planetě_, specifikované v GUI jako parametr. Přitahování je řešeno působením síly na **Rigidbody2D**.

#### Aiming
Při stisku kláves rotuje _Barrel_ vůči _Head_, což jsou podobjekty _Player_. Omezuje úhel hlavně.

#### Health
Odečítá životy, zobrazuje do _HealthSlider_ a ukončuje hru.

#### Movement
Pohyb _Playera_, využívá komponentu **Rigidbody2D** pro udělení síly. Protože tank je **Dynamic Rigidbody**, necháme engine spočítat umístění a rychlost ze sil, které na něj působí. Omezuje rychlost, aby tank neodletěl z planety.

#### Shooting
Řídí střelbu a prodlevu mezi střelami. Také zobrazuje stav do _PowerSlider_. Síla výstřelu se stiskem střílecí klávesy nejprve náhodně vygeneruje, pak se držením průběžně zvyšuje/snižuje. Puštěním střílecí klávesy se vytvoří v _FirePoint_ instance _Shot_, které je podle síly výstřelu udělena síla, jejíž úhel se spočte podle polohy _FirePoint_ vůči _Barrel_.


#### ShotDamage
Počítá _damage_ podle času letu a síly výstřelu. Toto zobrazí barvou střely, což je **Gradient** od bílé do oranžové.
Zpracuje event **OnTriggerEnter2D**, kterým se _Shot_ zničí a případně udělí _damage_ do _Player_. 

#### Meteor
Zpracuje event **OnTriggerEnter2D**, kterým se _Meteor_ zničí a případně udělí _damage_ do _Player_.
Pokud letí moc rychle kvůli gravitaci, tak ho zpomalí.


#### MeteorGeneration
Vyrábí _Meteory_ v náhodných místech s frekvencí závislou na hracím čase.


#### GUI skripty
Triviální.

## Závěr
Tvorbu jsem si užil a myslím, že jsem lépe připraven účastnit se v budoucnu nějakého Game Jamu. balanc fyzikálních konstant, aby byla hra zábavná. Někdy jsem váhal v rozhodnoutích o úrovni abstrakce, aby kód byl znovuvyužitelný, ale zároveň čitelný. Tvorba dokumentace byla obtížnější, než u pouze kódového projektu, protože jsem musel zvažovat, jak spolu objekty souvisí ve scéně, kterou jsem dělal graficky.
#### Co by šlo udělat dál
Možnost změny ovládání.
Více herních map/scén.
Změna fyzikálních vlastností za běhu.
Grafika, animace.
Lepší tvary tanků.
Umělá inteligence.
Testování.