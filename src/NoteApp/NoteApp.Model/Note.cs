﻿using System;
using Newtonsoft.Json;

namespace NoteApp.Model
{
    /// <summary>
    /// Текстовая заметка пользователя.
    /// Хранит информацию о названии, категории, тексте, времени создания и времени 
    /// последнего изменения заметки.
    /// Реализует интерфейсы <see cref="ICloneable"/> и <see cref="IEquatable{T}"/>
    /// </summary>
    public class Note : ICloneable, IEquatable<Note>
    {
        /// <summary>
        /// Название заметки.
        /// Ограничено 50 символами. Значение по умолчанию - "Без названия".
        /// </summary>
        private string _title = "Без названия";

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _category;

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;

        /// <summary>
        /// Время создания заметки. Значение по умолчанию - текущее время.
        /// </summary>
        private DateTime _creationTime = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки.
        /// </summary>
        private DateTime _modificationTime;

        /// <summary>
        /// Возвращает и задает название заметки.
        /// </summary>
        /// <exception cref="ArgumentException">Возникает, если название заметки содержит 
        /// более 50 символов.</exception>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Title length should not exceed 50 " +
                        "characters");
                }
                else
                {
                    // Если в качестве названия заметки передана пустая строка, присваиваем
                    // значение по умолчанию.
                    _title = value != string.Empty ? value : "Без названия";
                    ModificationTime = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает категорию заметки.
        /// </summary>
        public NoteCategory Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
                ModificationTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задает текст заметки.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                ModificationTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает и задает время создания заметки.
        /// </summary>
        public DateTime CreationTime
        {
            get
            {
                return _creationTime;
            }

            set
            {
                _creationTime = value;
            }
        }

        /// <summary>
        /// Возвращает и задает время последнего изменения заметки.
        /// </summary>
        public DateTime ModificationTime 
        { 
            get
            {
                return _modificationTime;
            }

            set
            {
                _modificationTime = value;
            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="Note"/>.
        /// </summary>
        public Note()
        {

        }

        /// <summary>
        /// Создает экземпляр <see cref="Note"/>.
        /// </summary>
        /// <param name="category">Категория заметки.
        /// Может принимать одно из следующих значений: "Работа", "Дом", "Здоровье и 
        /// спорт", "Люди", "Документы", "Финансы", "Разное"</param>
        public Note(NoteCategory category)
        {
            Category = category;
        }

        /// <summary>
        /// Создает экземпляр <see cref="Note"/>.
        /// </summary>
        /// <param name="title">Название заметки. Ограничено 50 символами.</param>
        /// <param name="category"><para>Категория заметки.</para> 
        /// Может принимать одно из следующих значений: "Работа", "Дом", "Здоровье и 
        /// спорт", "Люди", "Документы", "Финансы", "Разное".</param>
        /// <param name="text">Текст заметки.</param>
        /// <param name="creationTime">Время создания заметки.</param>
        /// <param name="modificationTime">Время последнего изменения заметки.</param>
        [JsonConstructor]
        public Note(string title, NoteCategory category, string text, DateTime creationTime, 
            DateTime modificationTime)
        {
            Title = title;
            Category = category;
            Text = text;
            CreationTime = creationTime;
            ModificationTime = modificationTime;
        }

        /// <summary>
        /// Метод, реализующий интерфейс <see cref="ICloneable"/> для создания копии объекта 
        /// <see cref="Note"/>.
        /// </summary>
        /// <returns> Поверхностная копия объекта <see cref="Note"/>.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Метод для сравнения текущего экземпляра <see cref="Note"/> с другим объектом 
        /// <see cref="Note"/>.
        /// </summary>
        /// <param name="other"> Экземпляр <see cref="Note"/>, с которым сравнивается 
        /// текущий объект <see cref="Note"/>.
        /// <returns> True, если объекты <see cref="Note"/> равны, и false в противном 
        /// случае.</returns>
        public bool Equals(Note other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return (Title == other.Title
                    && Category == other.Category
                    && Text == other.Text
                    && CreationTime.Equals(other.CreationTime)
                    && ModificationTime.Equals(other.ModificationTime));
        }

        /// <summary>
        /// Обобщенный метод для сравнения текущего объекта <see cref="Note"/> с другим 
        /// объектом.
        /// </summary>
        /// <param name="obj"> Объект, с которым сравнивается текущий объект <see cref="Note"/>.
        /// </param>
        /// <returns> True, если объект <see cref="Note"/> и объект <see cref="object"/> 
        /// равны, и false в противном случае.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Note)obj);
        }
    }
}
