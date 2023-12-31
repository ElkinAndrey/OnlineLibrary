﻿using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.Presentation.Dto.Book;

namespace OnlineLibraryAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы с книгами
    /// </summary>
    [Route("api/books/editions/languages")]
    [ApiController]
    public class EditionLanguageController : ControllerBase
    {
        /// <summary>
        /// Получить список книг
        /// </summary>
        [HttpPost("get")]
        public async Task<IActionResult> GetEditionLanguages([FromBody] GetEditionLanguagesDto record)
        {
            return Ok(new List<object>()
            {
                new
                {
                    BookId = new Guid("00000000-0000-0000-0000-513513513511"),
                    BookEditionId = new Guid("00000000-0000-0000-0000-875683898523"),
                    editionLanguageId = new Guid("00000000-0000-0000-0000-732677635525"),
                    Name = "ASP.NET Сборник рецептов",
                    GeneralDescription = "В книге собраны практические советы и примеры, которые помогут при создании веб-приложений с использованием ASP.NET: разработка архитектуры веб-приложения, его отладка, профилирование, защита, конфигурирование, работа с данными и многое другое. Рассмотрены специальные инструменты и утилиты, которые позволяют ускорить и упростить разработку и отладку веб-приложений. Уделено внимание обработке исключений в вебприложениях. Отдельная глава посвящена созданию отчетов в MS Excel. Книга будет полезна не только программистам, которые уже используют в своих разработках ASP.NET, но и тем, кто переходит на технологию ASP.NET с классической ASP или языка PHP. На компакт-диске приведен исходный код рассмотренных примеров.",
                    Year = 2015,
                    Description = "Данная книга для программистов-практиков. Не ищите в ней теоретических знаний — для этого есть множество замечательных изданий. Эта книга — набор готовых решений, советов и исходного кода. Предполагается, что читатель знаком с синтаксисом языка C#, имеет хотя бы небольшой опыт работы с ASP.NET и представление об архитектуре платформы .NET. Знания HTML и JavaScript тоже будут очень желательны, но не обязательны. Как минимум, слова \"скрипт\", \"postback\", \"база данных\", JavaScript, CSS, стили и т. д. не должны пугать новизной. Иначе, лучше начать с книги-введения в ASP.NET.",
                    NumberPages = 983,
                    EditionNumber = "Издание 1",
                    NumberAdditionsNotes = 1242,
                    NumberDownloads = 10255,
                    Topics = new List<object>() { "Программирование", "Матемтика" },
                    Authors = new List<object>() { "Дональд Кнуд", "Дэниель Абрамов" },
                    Publishers = new List<object>() { "БХВ-Петербург" },
                    Language = new
                    {
                        Id = "00000000-0000-0000-0000-676175725156",
                        Name = "Русский",
                        EnglishName = "Russian",
                        Abbreviation = "RU"
                    },
                },
                new
                {
                    BookId = new Guid("00000000-0000-0000-0000-671273579065"),
                    BookEditionId = new Guid("00000000-0000-0000-0000-765676475137"),
                    editionLanguageId = new Guid("00000000-0000-0000-0000-765787785713"),
                    Name = "CLR via C#",
                    GeneralDescription = "Эта книга, выходящая в четвертом издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т. д.",
                    Year = 2013,
                    Description = "Цель этой книги — объяснить, как разрабатывать приложения и многократно используемые классы для .NET Framework. В частности, это означает, что я собираюсь рассказать, как работает среда CLR и какие возможности она предоставляет разработчику. В этой книге также описываются различные классы стандартной библиотеки классов (Framework Class Library, FCL). Ни в одной книге невозможно описать FCL полностью — она содержит тысячи типов, и их число продолжает расти ударными темпами.",
                    NumberPages = 896,
                    EditionNumber = "4-е издание",
                    NumberAdditionsNotes = 430,
                    NumberDownloads = 2004,
                    Topics = new List<object>() { "Программирование" },
                    Authors = new List<object>() { "Джеффри Рихтер" },
                    Publishers = new List<object>() { "ООО Издательство «Питер»" },
                    Language = new
                    {
                        Id = "00000000-0000-0000-0000-657849819657",
                        Name = "English",
                        EnglishName = "English",
                        Abbreviation = "EN",
                    },
                },
            });
        }

        /// <summary>
        /// Получить количество книг
        /// </summary>
        [HttpPost("count")]
        public async Task<IActionResult> GetEditionLanguagesCount([FromBody] GetEditionLanguagesCountDto record)
        {
            return Ok(123);
        }

        /// <summary>
        /// Получить книгу по Id
        /// </summary>
        [HttpGet("{editionLanguageId}")]
        public async Task<IActionResult> GetEditionLanguageById(Guid editionLanguageId)
        {
            return Ok(
                new
                {
                    BookId = new Guid("00000000-0000-0000-0000-513513513511"),
                    EditionId = new Guid("00000000-0000-0000-0000-875683898523"),
                    EditionLanguageId = new Guid("00000000-0000-0000-0000-732677635525"),
                    Name = "ASP.NET Сборник рецептов",
                    GeneralDescription = "В книге собраны практические советы и примеры, которые помогут при создании веб-приложений с использованием ASP.NET: разработка архитектуры веб-приложения, его отладка, профилирование, защита, конфигурирование, работа с данными и многое другое. Рассмотрены специальные инструменты и утилиты, которые позволяют ускорить и упростить разработку и отладку веб-приложений. Уделено внимание обработке исключений в вебприложениях. Отдельная глава посвящена созданию отчетов в MS Excel. Книга будет полезна не только программистам, которые уже используют в своих разработках ASP.NET, но и тем, кто переходит на технологию ASP.NET с классической ASP или языка PHP. На компакт-диске приведен исходный код рассмотренных примеров.",
                    Year = 2015,
                    Description = "Данная книга для программистов-практиков. Не ищите в ней теоретических знаний — для этого есть множество замечательных изданий. Эта книга — набор готовых решений, советов и исходного кода. Предполагается, что читатель знаком с синтаксисом языка C#, имеет хотя бы небольшой опыт работы с ASP.NET и представление об архитектуре платформы .NET. Знания HTML и JavaScript тоже будут очень желательны, но не обязательны. Как минимум, слова \"скрипт\", \"postback\", \"база данных\", JavaScript, CSS, стили и т. д. не должны пугать новизной. Иначе, лучше начать с книги-введения в ASP.NET.",
                    NumberPages = 983,
                    EditionNumber = "Издание 1",
                    NumberAdditionsNotes = 1242,
                    NumberDownloads = 10255,
                    Topics = new List<object>() { "Программирование", "Матемтика" },
                    Authors = new List<object>() { "Дональд Кнуд", "Дэниель Абрамов" },
                    Publishers = new List<object>() { "БХВ-Петербург" },
                    Language = new
                    {
                        Id = "00000000-0000-0000-0000-676175725156",
                        Name = "Русский",
                        EnglishName = "Russian",
                        Abbreviation = "RU"
                    },
                    FileExtensions = new List<object>() 
                    { 
                        new 
                        {
                            Id = new Guid("00000000-0000-0000-0000-712757818252"),
                            Name = "png"
                        }, 
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-879881242142"),
                            Name = "epub"
                        } 
                    },
                    BooksSameEdition = new List<object>()
                    {
                        new
                        {
                            EditionId = new Guid("00000000-0000-0000-0000-986135766173"),
                            EditionLanguageId = new Guid("00000000-0000-0000-0000-767117571235"),
                            Year = 2016,
                            Description = "Данная книга для программистов-практиков. Не ищите в ней теоретических знаний — для этого есть множество замечательных изданий. Эта книга — набор готовых решений, советов и исходного кода. Предполагается, что читатель знаком с синтаксисом языка C#, имеет хотя бы небольшой опыт работы с ASP.NET и представление об архитектуре платформы .NET. Знания HTML и JavaScript тоже будут очень желательны, но не обязательны. Как минимум, слова \"скрипт\", \"postback\", \"база данных\", JavaScript, CSS, стили и т. д. не должны пугать новизной. Иначе, лучше начать с книги-введения в ASP.NET.",
                            NumberAdditionsNotes = 155,
                            NumberPages = 956,
                            EditionNumber = "Издание 2",
                            NumberDownloads = 2512,
                        },
                        new
                        {
                            EditionId = new Guid("00000000-0000-0000-0000-713785781783"),
                            EditionLanguageId = new Guid("00000000-0000-0000-0000-786781257125"),
                            Year = 2018,
                            Description = "Данная книга для программистов-практиков. Не ищите в ней теоретических знаний — для этого есть множество замечательных изданий. Эта книга — набор готовых решений, советов и исходного кода. Предполагается, что читатель знаком с синтаксисом языка C#, имеет хотя бы небольшой опыт работы с ASP.NET и представление об архитектуре платформы .NET. Знания HTML и JavaScript тоже будут очень желательны, но не обязательны. Как минимум, слова \"скрипт\", \"postback\", \"база данных\", JavaScript, CSS, стили и т. д. не должны пугать новизной. Иначе, лучше начать с книги-введения в ASP.NET.",
                            NumberAdditionsNotes = 51,
                            NumberPages = 1004,
                            EditionNumber = "Издание 3",
                            NumberDownloads = 623,
                        }
                    },
                }
            );
        }

        /// <summary>
        /// Получить другие языки издания
        /// </summary>
        [HttpPost("{editionLanguageId}/other/get")]
        public async Task<IActionResult> GetOtherLanguageEditions(Guid editionLanguageId, GetOtherEditionLanguagesDto model)
        {
            return Ok(new List<object>()
                {
                    new
                    {
                        EditionLanguageId = new Guid("00000000-0000-0000-0000-767117571235"),
                        NumberPages = 956,
                        NumberAdditionsNotes = 155,
                        NumberDownloads = 2512,
                        Language = new
                        {
                            Id = "00000000-0000-0000-0000-657849819657",
                            Name = "English",
                            EnglishName = "English",
                            Abbreviation = "EN"
                        },
                    },
                    new
                    {
                        EditionLanguageId = new Guid("00000000-0000-0000-0000-786781257125"),
                        NumberPages = 1004,
                        NumberAdditionsNotes = 125,
                        NumberDownloads = 651,
                        Language = new
                        {
                            Id = "00000000-0000-0000-0000-565787564746",
                            Name = "Український",
                            EnglishName = "Ukrainian",
                            Abbreviation = "UA"
                        },
                    }
                }
            );
        }

        /// <summary>
        /// Получить количество других языков издания
        /// </summary>
        [HttpPost("{editionLanguageId}/other/count")]
        public async Task<IActionResult> GetOtherLanguageEditionsCount(GetOtherEditionLanguagesCountDto model)
        {
            return Ok(21);
        }

        /// <summary>
        /// Получить обложку языка издания по Id
        /// </summary>
        [HttpGet("{editionLanguageId}/cover")]
        public async Task<IActionResult> GetBookCoverByEditionLanguageId(Guid editionLanguageId)
        {
            return File(new FileStream($"HelpFiles\\Cover.png", FileMode.Open), "image/png");
        }

        /// <summary>
        /// Добавление языка к уже существующему изданию
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> AddEditionLanguage()
        {
            return Ok();
        }
    }
}
