# Player State Machine

Демонстрационный проект: State Machine + DI (Zenject) для управления игроком в Unity.

## Что внутри

- `IState` / `ITickableState` / `IFixedTickableState` — интерфейсы состояний
- `StateMachine` — управление переходами между состояниями
- `StateFactory` — создание состояний через Zenject
- `PlayerIdleState`, `PlayerWalkState` — конкретные состояния
- `Player`, `PlayerMovement`, `PlayerConfig` — игрок и его движение
- `IInputProvider` — абстракция ввода (New Input System)
- `IMoveable` — абстракция движения
- `GameInstaller` — DI-биндинги

## Стек

- Unity 6.3
- C#
- Zenject
- New Input System

## Запуск

1. Открыть сцену `Main`
2. Нажать Play
3. WASD — движение

## Заметки

- Проект для портфолио, цель — показать архитектуру.