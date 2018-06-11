# Withstand
Игра, написанная на C# с использованием движка Unity.

Члены проекта: Белоруссова Юлия, Зелинский Дмитрий, Ильиных Иван.

Точки расширения:  
1. [Creature.cs](Assets/Scripts/Models/Creatures/Creature.cs)  //  создание новых, возможно, нейтральных персонажей;
2. [Enemy.cs](Assets/Scripts/Models/Creatures/Enemy.cs)  // создание новых вражеских существ;
3. [Item.cs](Assets/Scripts/Models/Item.cs)  // создание новых вещей (оружие, броня и прочее).


DI-Containers:
DI-Container'ы в Unity используются редко, и в данной задаче их использование излишнее. Injection Dependency - это инверсия шаблона управления. Unity опирается на компонентный шаблон, в котором используется шаблон Service Locator, который также является инверсией шаблона управления.
GetComponent, FindObjectOfType - примеры использования Service Locator.
