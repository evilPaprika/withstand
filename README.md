# Withstand
Игра, написанная с использованием движка Unity. 
Члены проекта: Белоруссова Юлия, Зелинский Дмитрий, Ильиных Иван

Точки расширения:  
[Creature.cs](Assets/Scripts/Models/Creatures/Creature.cs)  //  создание новых, возможно, нейтральных персонажей
[Enemy.cs](Assets/Scripts/Models/Creatures/Enemy.cs)  // создание новых вражеских существ
[Item.cs](Assets/Scripts/Models/Item.cs)  // создание новых вещей (оружие, броня и прочее)


DI-Containers:
DI-Container'ы в Unity используются редко, и в данной задаче их использование излишнее. Injection Dependency - это инверсия шаблона управления. Unity опирается на компонентный шаблон, в котором используется шаблон Locator Service, который также является инверсией шаблона управления.

