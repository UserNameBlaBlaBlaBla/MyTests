Необходимо отредактировать объект с помощью PropertyGrid. Редакторы, которые изменяют значения примитивных типов данных, строк и **инициализированных** объектов, работают корректно. 

Проблема: при попытке редактировать **неинициализированное** ссылочное свойство редактор захватывает фокус и после этого **невозможно перевести фокус** на другой редактор до выбора другого объекта.

PropertyGrid реализовал по примеру:

https://eremexcontrols.net/articles/controls/propertygrid/custom-editors.html#dynamically-assign-editors-based-on-row-data-type

Как можно исправить такое поведение редакторов?