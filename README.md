# Описание проекта

Веб-приложение создано для определения эмоционального окраса текста.
Пользователь вводит текст, на основе которого производится анализ: в процентном соотношении указываются 8 базовых эмоций(по модели цветового круга Плутчика):
- радость 
- доверие
- страх
- удивление
- печаль 
- брезгливость
- гнев
- ожидание

Приложению на вход подается текст, который анализируется по заданному базису. Базис основан на составлении списка соотношений слов к эмоциональному окрасу (на основе 8 базовых эмоций). Итогом анализа является определенное значение для каждой базовой эмоции.
Каждому слову в введенном тексте ставятся в соответствие 8 значений, полученные при анализе. С каждым последующим анализом текста указанные 8 значений повторяющихся слов уточняются (усредняются) и таким образом для каждого слова формируется более точное значение относительно спектра эмоций.
Система также учитывает приоритет слов в предложениях (например, предлог и подлежащее имеют разную важность при анализе).
