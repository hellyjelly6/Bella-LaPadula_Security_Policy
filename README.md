# Bella-LaPadula_Security_Policy
Реализация и исследование политики безопасности Белла-ЛаПадула.


Пусть множество возможных операций субъектов S над объектами O задано в следующей форме: {«READ (доступ по чтению)», «WRITE (доступ по записи)», «CHANGE (изменение уровня доступа субъекта)»}.
Пусть множество атрибутов безопасности A задано в виде A={NONCONFIDENTIAL, CONFIDENTIAL, SECRET, TOP SECRET}.
1.	Для кодирования в программной модели атрибутов безопасности множества A можно закодировать их числами от 0 до 3 (от низших к высшим уровням безопасности), например, NONCONFIDENTIAL=0, CONFIDENTIAL=1, SECRET=2, TOP SECRET=3. В этом случае более легко можно реализовать контроль допуска субъектов к объектам.
2.	Для хранения в программной модели уровней конфиденциальности объектов и уровней допуска субъектов рекомендуется использовать два массива, которые должны заполняться случайным образом (за исключением уровня допуска администратора).
3.	Необходимо хранить копию начальных уровней доступа субъектов для контроля их не превышения в результате выполнения операции change.
3.	Реализовать программный модуль, демонстрирующий работу пользователя в мандатной модели политики безопасности. Данный модуль должен выполнять следующие функции:
3.1.	При запуске модуля – распечатать на экране сформированную модель БЛМ – уровни конфиденциальности объектов и уровни допуска субъектов.
3.2.	Запрос идентификатора пользователя (должна проводиться его идентификация). В случае успешной идентификации пользователя должен осуществляться вход в систему, в случае неуспешной – выводиться соответствующее сообщение.
3.3.	По результатам идентификации субъекта после входа в систему, программа должна ждать указаний пользователя на осуществление действий над объектами в компьютерной системе. После получения команды от пользователя, на экран должно выводиться сообщение об успешности либо не успешности операции. При выполнении операции изменения уровня доступа субъекта (change) данный уровень должен модифицироваться. Должна поддерживаться операция выхода из системы (exit), после которой, на экран вновь должна выводиться информация об уровнях доступа субъектов и уровнях конфиденциальности объектов и запрашиваться другой идентификатор пользователя. 
