import pandas

csv_file = None


# Открываю csv файл
def file_open():
    global csv_file
    try:
        data = pandas.read_csv('data.csv', delimiter=";")
    except Exception as e:
        print(e)
    print('Файл открыт. Записей:', len(data.index))
    csv_file = data


# Добавление данных
def insert(fio, age, tel, otd):
    global csv_file
    try:
        df_insert = pandas.DataFrame([(max(csv_file['ном'] + 1), fio, age, tel, otd)],
                                     columns=('ном', 'фио', 'возраст', 'телефон', 'отдел'))
        csv_file = pandas.concat([csv_file, df_insert])
    except Exception as e:
        print(f'Ошибка при добавленнии новой записи {e}')
    print("Данные добавлены.")


# Удалить по аргументу
def drop_by_arg(val, col_name='фио'):
    global csv_file
    if col_name == 'ном' or col_name == 'возраст':
        val = int(val)
    csv_file = csv_file[csv_file[col_name] != val]
    print(f'Строка со значением "{val}" столбца "{col_name}" удалена.')


# Поиск
def find(val, col_name='фио'):
    df = csv_file[csv_file[col_name].isin([val])]
    print(df)


# Средний возраст
def avg_age():
    print("Средний возраст:", round(csv_file["возраст"].mean(), 2))


# Сохранение
def save():
    try:
        csv_file.to_csv('data.csv', index=False, sep=';')
    except Exception as e:
        print("Ошибка при сохранении в csv ", e)
    print("Данные сохранены.")


# Открыт ли файл или нет
def show_csv():
    if csv_file.__class__.__name__ == 'NoneType':
        print(type(csv_file))
    else:
        print(csv_file)
