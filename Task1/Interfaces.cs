using System;
using System.Collections.Generic;

namespace Task1 {
// Общие сведения, которые есть у любого документа абитуриента.
public interface IDocument {
  string Title { get; }
  string Number { get; }
  DateTime IssueDate { get; }

  // Текстовое описание документа.
  string GetInfo();
}

// Документ, который умеет проверять корректность своих данных.
public interface IValidatable {
  // Возвращает список найденных ошибок (пустой, если ошибок нет).
  List<string> Validate();
}

// Документ, который приносит абитуриенту конкурсные баллы.
public interface IScorable {
  int GetScore();
}

// Документ, который можно сохранить в текстовый файл и загрузить из него.
// Документ хранится как раздел [Section] со строками вида "ключ=значение".
public interface IStorable {
  string Section { get; }

  List<string> Save();

  void Load(string key, string value);
}
}
