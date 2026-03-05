# Система выбора конфигов в редакторе Unity

## Описание
Данная система позволяет выбирать различные конфигурационные файлы (ScriptableObject) прямо в редакторе Unity через удобный интерфейс.

## Компоненты системы

### 1. MyInstallerEditor.cs
- Custom Editor для компонента MyInstaller
- Позволяет выбрать тип провайдера конфига (ScriptableObject или Dummy)
- При выборе ScriptableObject показывает выпадающий список доступных Settings файлов
- Сохраняет выбор в PlayerPrefs

### 2. ConfigManager.cs
- Содержит меню Tools для управления конфигами
- "Tools/Update Active Config" - обновляет активный конфиг в Resources
- "Tools/Create New Config" - создает новый Settings ассет
- "Tools/Create Test Configs" - создает тестовые конфиги (Development, Production, Debug)

### 3. ScriptableObjectGameConfigProvider.cs
- Загружает конфиг из Resources/Settings.asset
- Использует выбранный конфиг в игре

## Как использовать

### 1. Выбор конфига в редакторе:
1. Добавьте компонент MyInstaller на GameObject в сцене
2. В инспекторе выберите тип провайдера "ScriptableObject"
3. В выпадающемся списке "Select Config Asset" выберите нужный Settings файл
4. Нажмите "Tools/Update Active Config" чтобы применить изменения

### 2. Создание новых конфигов:
1. Используйте "Tools/Create New Config" для создания нового Settings ассета
2. Или используйте "Tools/Create Test Configs" для создания тестовых конфигов

### 3. Создание Settings файлов вручную:
1. Щелкните правой кнопкой мыши в Project окне
2. Выберите "Create/Settings" 
3. Назовите файл и настройте параметры

## Особенности
- Система автоматически находит все Settings файлы в проекте
- Поддерживает создание и выбор различных конфигураций
- Позволяет быстро переключаться между конфигами в редакторе
- Совместима с системой зависимостей Zenject

## Структура файлов
```
Assets/
├── _Core/
│   ├── Scripts/
│   │   ├── Config/
│   │   │   └── Settings.cs (ScriptableObject)
│   │   ├── Editor/
│   │   │   ├── MyInstallerEditor.cs
│   │   │   ├── ConfigManager.cs
│   │   │   └── CreateTestConfigs.cs
│   │   └── ScriptableObjectGameConfigProvider.cs
└── Resources/
    └── Settings.asset (активный конфиг)
```

## Примеры конфигов
- DevelopmentSettings: высокие параметры для разработки
- ProductionSettings: стандартные игровые параметры  
- DebugSettings: экстремальные значения для отладки