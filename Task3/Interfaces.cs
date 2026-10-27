using System.Collections.Generic;
using Task1;

namespace Task3 {
// Реестр абитуриентов: регистрация, поиск и удаление.
public interface IAbiturientRegistry {
  void Register(Abiturient abiturient);

  bool Remove(string key);

  Abiturient Find(string key);

  List<Abiturient> GetAll();
}

// Конкурсные списки по направлениям подготовки.
public interface IRatingService {
  // Все абитуриенты, выбравшие направление, по убыванию баллов.
  List<RatingEntry> GetRating(Specialty specialty);

  // Абитуриенты, рекомендованные к зачислению на направление.
  List<RatingEntry> GetAdmitted(Specialty specialty);
}
}
