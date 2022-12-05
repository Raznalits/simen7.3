import json
import os

class DataBase:
    def __init__(self, file_name):
        self.file_name = file_name

        if os.path.exists(self.file_name):
            with open(self.file_name, encoding='utf-8') as f:
                self.students = json.load(f)

        else:
            self.students = []
    def save(self):
        with open(self.file_name, 'w', encoding='utf-8') as f:
            json.dump(self.students, f, ensure_ascii=False)
    def get(self, num):
        return self.students[num - 1]

    def add_student(self, name, surname, age):
        self.students.append({"Имя": name, "Фамилия": surname, "Возраст": age})
        self.save()

    def select_by_age(self, age):
        return [x for x in self.students if x['Возраст'] == age]


if __name__ == '__main__':
    db = DataBase('students.json')

    print('''\
Выберите действие:
    1 - добавить студента,
    2 - показать по номеру,
    3 - показать по возрасту,
    4 - показать из файла,
    0 - выход
''')

    while True:
        f = input('Выберите действие:  ')
        if f == '1':
            print('Введите данные через пробел (имя, фамилия, возраст)')
            name, surname, age = input().split()
            db.add_student(name, surname, age)

        elif f == '2':
            num = int(input('Номер ->  '))
            print(db.get(num))

        elif f == '3':
            items = db.select_by_age(input('Возраст-> '))
            print(items)

        elif f == '4':
            with open(db.file_name, encoding='utf-8') as f:
                text = f.read()
                print(repr(text))

        else:
            break

    # Save file
    db.save()