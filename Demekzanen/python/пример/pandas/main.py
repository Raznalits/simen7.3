from pandas_csv import file_open, insert, avg_age, drop_by_arg, find, save, show_csv

MENU = {
    '1': 'Открыть файл',
    '2': 'Добавить',
    '3': 'Удалить',
    '4': 'Найти по значению',
    '5': 'Вывести средний возраст',
    '6': 'Сохранить в файл',
    '7': 'Вывести записи',
    '0': '<-Меню',
    'exit': 'Выход'
}

# Вывод меню
print('\n'.join([f"{k} : {v}" for k, v in MENU.items()]))
while True:
    comand = input()
    if comand == '1':
        file_open()
    elif comand == '2':
        insert(input('ФИО: '), int(input('Возраст: ')), input('Телефон: '), input('Отдел: '))
    elif comand == '3':
        col = input('Колонка: ')
        val = input('Значение: ')
        drop_by_arg(val, col_name=col)
    elif comand == '4':
        col = input('Колонка: ')
        val = input('Значение: ')
        find(val, col_name=col)
    elif comand == '5':
        avg_age()
    elif comand == '6':
        save()
    elif comand == '7':
        show_csv()
    elif comand == '0':
        print('\n'.join([f"{k} : {v}" for k, v in MENU.items()]))
    elif comand == 'exit':
        break
