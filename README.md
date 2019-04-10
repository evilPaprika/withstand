# Withstand
Мультиплеерный top down шутер, написанный на движке Unity.

Члены проекта: Белоруссова Юлия, Зелинский Дмитрий, Ильиных Иван.

### Игры, которыми мы вдохновлялись
  - Cataclysm DDA
  - Hotline Miami
  - Left4Dead
  - Survivio
  - Devil Daggers
  - Project Zomboid
  - Factorio
 
### Суть игры
  Выживать вместе с товарищами, обороняясь от орд зомби, и искать еду, чтобы не умереть с голоду.

### Точки расширения  
  - [Creature.cs](Assets/Scripts/Creatures/Creature.cs)  //  создание новых, возможно, нейтральных персонажей;
  - [Enemy.cs](Assets/Scripts/Creatures/Enemy.cs)  // (наследник от Creature) создание новых вражеских существ;
  - [Item.cs](Assets/Scripts/Items/Item.cs)  // создание новых вещей (оружие, броня и прочее);
  - [Generator.cs](Assets/Scripts/WorldGen/Generator.cs)  // генератор объектов мира;
  - [PickUps.cs](Assets/Scripts/Items/PickUps.cs)  // абстрактный класс описываюший поднимаемые объекты;
  - [SliderHandler.cs](Assets/Scripts/GUI/SliderHandler.cs)  // навешивается на любой слайдер, и его становится легко изменять;
  - [Indicator.cs](Assets/Scripts/Creatures/Indicator.cs)  // индикатор состояния объекта, можно сделать сколько угодно для одного объекта;
  - [Projectile.cs](Assets/Scripts/Items/Weapons/Projectiles/Projectile.cs)  // описывает абстрактный метательный снаряд
  - [WeaponItem.cs](Assets/Scripts/Items/ItemTypes/WeaponItem.cs)  // абстрактное оружие

### DI-Containers:
DI-Container'ы в Unity используются редко, и в данной задаче их использование излишнее. Injection Dependency - это инверсия шаблона управления. Unity опирается на компонентный шаблон, в котором используется шаблон Service Locator, который также является инверсией шаблона управления.
GetComponent, FindObjectOfType - примеры использования Service Locator.

### Общая структура решения
Движок Unity уже частично предоставляет модель структуры. Например, [сцены](Assets/Scenes) предоставляют возможность cодержать в себе игровые объекты и элементы интерфейса.
Основная часть логики - это [скрипты](Assets/Scripts), которые позволяют задать взаимодействия между игровыми объектами или сделать желаемый функционал.
