using API.DAL.Models;
using API.DAL.Models.Data;

namespace API.DAL.DataAccess
{
    public static class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.Movies.Any())
                    return;
                var genres = new Genre[]
                {
                    new Genre {Name = "Боевик"},
                    new Genre {Name = "Комедия"},
                    new Genre {Name = "Военный фильм"},
                    new Genre {Name = "Криминальный"},
                    new Genre {Name = "Триллер"},
                    new Genre {Name = "Детектив"},
                    new Genre {Name = "Драма"},
                    new Genre {Name = "Ужасы"},
                    new Genre {Name = "Фэнтези"},
                    new Genre {Name = "Научная фантастика"},
                    new Genre {Name = "Анимация"},
                    new Genre {Name = "Документальный"},
                    new Genre {Name = "Исторический"},
                    new Genre {Name = "Романтический"},
                    new Genre {Name = "Фантастика"},
                    new Genre {Name = "Музыкальный"}
                };
                genres.ToList().ForEach(gen => context.Genres.Add(gen));

                var movies = new Movie[]
                {
                    new Movie{ 
                        Name = "Совместная поездка", 
                        Genres=genres.ToList().Take(2).ToList(),
                        Cover = "https://i.imgur.com/LXqqUTl.jpg",
                        Description = "Охранник Бен отправляется вместе со своим шурином Джеймсом в патруль по Атланте, чтобы доказать, что он достоин жениться на Анджеле, сестре Джеймса.",
                        Rating = 5,
                        Year = 2014,
                        Url = "https://vk.com/video_ext.php?oid=-138993550&id=456243467&hash=d86fdb367e8663f7",
                        Tagline = "Propose to this cop's sister? Rookie mistake",
                        Director = "Тим Стори",
                        Screenwriter = "Джейсон Манцукас, Фил Хэй, Мэтт Манфреди",
                        Producer = "Мэтт Альварес, Ларри Брэзнер, Айс Кьюб",
                        Videographer = "Ларри Блэнфорд",
                        Composer = "Кристофер Леннерц",
                        Drawer = "Крис Корнвэлл, Пол Лютер Джексон, Роб Саймонс",
                        Montage = "Крэйг Элперт",
                        Budget = 25000000,
                        Collected = 154468902,
                        Premier = new DateOnly(2014, 1, 17),
                        Age = 16
                    },
                    new Movie{
                        Name = "На Западном фронте без перемен",
                        Genres=new List<Genre>{genres[2]},
                        Cover = "https://upload.wikimedia.org/wikipedia/ru/4/49/%D0%9D%D0%B0_%D0%97%D0%B0%D0%BF%D0%B0%D0%B4%D0%BD%D0%BE%D0%BC_%D1%84%D1%80%D0%BE%D0%BD%D1%82%D0%B5_%D0%B1%D0%B5%D0%B7_%D0%BF%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD_%282022%29_-_%D0%BF%D0%BE%D1%81%D1%82%D0%B5%D1%80.png",
                        Description = "Германская империя, 1917 год. Преисполненные патриотизмом 19-летний Пауль Боймер и его друзья-одноклассники отправляются добровольцами на фронт, где им предстоит испытать на себе ужасы Первой мировой войны.",
                        Rating = 0,
                        Year = 2022,
                        Url = "https://vk.com/video_ext.php?oid=-138993550&id=456244044&hash=0da2765f891b4656",
                        Tagline = "In the midst of the chaos and brutality of World War One trench warfare, there is still hope",
                        Director = "Эдвард Бергер",
                        Screenwriter = "Эдвард Бергер, Лесли Патерсон, Иэн Стокелл",
                        Producer = "Эдвард Бергер, Даниэль Брюль, Даниэль Марк Дрейфусс",
                        Videographer = "Джеймс Френд",
                        Composer = "Фолькер Бертельман",
                        Drawer = "Кристиан М. Гольдбек, Патрик Херцберг, Индржих Кочи",
                        Montage = "Свен Будельман",
                        Premier = new DateOnly(2022, 9, 12),
                        Age = 16
                    },
                    new Movie{
                        Name = "Гангстер, коп и дьявол",
                        Genres=new List<Genre>{genres[0],genres[3]},
                        Cover = "https://www.kinopoisk.ru/2Q9X2l433/bb8ddck78/N_X8OoJjt-peYhJ2UgbfnTRWBWQX_45FbEK7d0dFbKtnBrZWK6OpQIhyRvFRFqlRRysBGv1ix3Slr2NNggo-pQb9_GfTH_OafmtqK2dO7tUxazARQ7vXZDVSzzoyKBAXp6Z-8-M7VeAIw8PoUArAGDJKABLNXoIU_e8yhDcHt_DTKdBuzv-SgtIS865mkm_pEAf5EIeOJsEcA2cT_12cW4vGWvd72w1c2OMj9Mj_SKiazhAe6VJyDWEb4uhGx_tIA3lE3oqDImrCLs_2ZmYvkQD78dDHYqL9RM83b8cpkENLwr7Dr6uZcEDzx3BAh_Swik7oTikSnnWZKyZQhu-ngJdpuMo-J9Ia1rr7bjJSh9VIF928j0Z2xcg357szXXRPv2bG34snhSw0J-O40G9gDC66ONbh_spRkRO2EALPI6ivodimUiMeOmYiw2biamtZFB9twNdi2j0cO6tXu1GIV3N-ZhuX49WgnIPLbOTbVJjSYuxyvW7K8e3rjsAay3scA23AoibLbpIyOkNaDg7PtSy_OYCzZpr9WFsny-9ZWG9rjt7PD7MFDBivQ-gcX9C8ypIIBrV2RnWF645Q7t9LCAcJqIKS4-ZGyhpjUpKqX1msM6UQUyLSBbi7G0e_5XwDb0bK31OjlVSoWxvUBPt0pMISAN55wmKxXZMycIZLy2gL7TQKtpOuzjKifw4CxiNBuCs1GKvyKgFs86_zU80Yv1fiErsn09EMCG-vjKy_XGSmznDO7W4WEa3nWihmC09EV00gUmIfRjruKo_2hppzsUQTqfSbsi4J4NsXjzPd8MdfGk7ft4_B1Jw7b3xIvzAYEtZU4t3mXm19F0L8fhtrWNeFwAKqj7r2Sv7T5iIq3xkYHzX4Y04C1XzLt4f3NRRT14rqL5PLGeyw_3-IoPs0HAJi4EZlSoKVTS86wGJTI4QPMThuoh9ehr5Wk5YGRssVtL8FRKsK7hHMdyezQ23YP_-ORnNDo8kYEOtf8LwT7GTG_gBW2a6qncEfYlRqR38oU4VMKiILcm72EveWkhbbPeirncwHEvq99IeDF9uheCMzkkbXr8dV1ATfu2zU77B0nmI4ThVeHi39464k2rubcKfJxO6uCxrGwqb7bgpqw8WMhwXYE2p2hcizm2OjJdhHwz4mH4M32ZAIhzOskJdcnFIi3AIV3uoBWT-u0M7TYxCrPeDa0js2guLqk2aOmjcdrJ-RFEcWoh3wy6dfC5UYy19iGsd_n90UpAcriNh3aIRKKjQyUW5a6YFrrvTmyz8gG-nYOhYjat4i_uNSvuoD0UAb-ZjPTvKVwFtHU0Od5IsLMqpX18NRkAQn76gkC2AUCm6s9lHWXn2l89Lk0ovPhO-hsDbia7KKVl4HkvLm9xEoE63AH5a-iVzHa4vLmeTjuxYmQ9ePTRwsp--saGu0uE5ihA51vmIloZNiPFbD6_RjSbjiYmNutj5Oiw7iXgOdQD_xBJdKtkngn8vDS5XEyxeeSu-_Y8EcUCM7eCyf7HBO0ihelc7epdEzWqxyl7_om0VAbh6XJnbKdnuO6man7agvHUCTxhpN1Dunk19dGF9nnko7g5f9CCArQyRA98iMqna4Fjl--uGJk8Jgfks7TH-lGN7WgzJmLhrzxga609GApyXY3womBSxTGwPP2fgPCypW59uD3RAcI7dc7DdIhDJm1Br1bgI9nf-yMJKTb_i3vcRKurf24iamSwZu6sOBpGvxuBdO_tHMW99vOxmY_wOyfssvS6XUwAen0NQLcHTemmTGEX5uXeEHOkB2g9dUq-XgUrqnzlZmxr9iApb_bWzvsYyvYiZd2As78z_J7DtLStZfRx8FLHR_Q-y8S_wsrkI0XuHmJpUZZ2JgYlerdB8hfE7mHzYeSvaL8obOz2ngJ3G4P2Ia1TDPO8c7qYDnjyY-97uDzUxw_18EEA_g6N6SsO6hup6Nbb_6YO4vx2DjvfCq0ovaziJGO5YCig_JyHddaCMmhknQq0fvK1nkR_NKwj9Hm11kqE_z9CBbRDhernxmYcbyPZkL_swCx5v450VUjkIDKoa6xpsGrj6_AXiT_XTXbhp59NcXzyt1xMtP-krnGyM94Lgr2yQo59wELqo0ejHaciHlh-JMQkNnlJPNyN7mu_56DjJ_yjKW-7mkBwVkEw5SwVh7qwN3xcCjy2LKcxNDDQgoL2uEpMfICLqS8E5R2t4hpWN-nKqT51ADmdjuWmua1i7Wd6p6Yke98HsR2M8S-p2sM4PH_72cuztGwlszo9FsAH9PANQLzIx-LqgC0bqqlRUjOiCSu0OMb72cWlZPGuYKyv_SYiY3IawLrfwfvjpNYKdnE-tVgKPj4sons9-90NSDI3TEy7AMyiYoHtWqyrXBd9JMglevxOsdSGbeP04K8tbDcnJef20I11WIK6qmvdgPL5d_YehDHxKa648zxXx0yy_kxHPEBKqSoAZ9Vh6RmUMuWPYbZyCrJWjmbu_-Fu4mv_r2HkO1nDPh9E_-FuHch6MzexXIj8PixqMLSxX0LC-f6JBPGFBCOiAWlS529RVrapx2F18QNzVw0uI_2kIuVg9Wbg77FTQXaVSHKla9XMtnf3_1cHcXhjLbr989TPTzqzis_yyoUhboailaymlxa2o86jf_hA9lyGIqi1LWcuJDKupaRzWEH2VAx05aUbxDO1PvsWinA_p2mwOv0RCAB6N41OekXH6mEDKVIpLpHbcqUArPp0grqTxuTotOVloyT4ZyinddjO9pTAvuHrFwj0vn17HIbws28uuXjz2cjN8TZMRTkOg2LlRy1TJiDWU39uTuY39M_wl0ZkIXGn4mImNWji6rsTRvHbxfooL5TA8349v5zM8_ZuI__291fMzbY2CIk7SMovasYmFe3mkZ6_osKltjlCO5YC6-A7pu8kI7mg7G_yEUG7GIG8aqGWhXn-fXKcD3s7JmHyfTTXyYh-NsGHvIDIZG-Go1ygIRdSNg",
                        Description = "Бандит и детектив объединяются, чтобы поймать серийного убийцу. Дерзкий криминальный триллер из Южной Кореи",
                        Rating = 0,
                        Year = 2019,
                        Url = "https://vk.com/video_ext.php?oid=-138993550&id=456243881&hash=4fe14c3063b65e25",
                        Tagline = "Не дай дьяволу выиграть",
                        Director = "Ли Вон-тхэ",
                        Screenwriter = "Ли Вон-тхэ",
                        Producer = "Чан Вон-сок, Со Ган-хо, Чон Хён-джу",
                        Videographer = "Пак Сэ-сын",
                        Composer = "Чо Ён-ук",
                        Drawer = "Чо Хва-сон, Чон И-джин, Нам Джи-су",
                        Montage = "Хо Сон-ми, Хан Ён-гю",
                        Budget = 6500000,
                        Collected = 25775371,
                        Premier = new DateOnly(2019, 5, 15),
                        Age = 18
                    },
                    new Movie{
                        Name = "Всевидящее око",
                        Genres=new List<Genre>{genres[4],genres[5]},
                        Cover = "https://www.kinopoisk.ru/2Q9X2l433/bb8ddck78/N_X8OoJjt-peYhJ2UgbfnTRWBWQX_45FbEK7d0dFbKtnBrZWK6OpQIhyRu1FFr1lVzcAW7g7j2SA5j9MzhdmnQb8pSvXHpu3NyNqG1IW95RxfmwUEuqnZDVSzzoyKBAXp6Z-8-M7VeAIw8PoUArAGDJKABLNXoIU_e8yhDcHt_DTKdBuzv-SgtIS865mkm_pEAf5EIeOJsEcA2cT_12cW4vGWvd72w1c2OMj9Mj_SKiazhAe6VJyDWEb4uhGx_tIA3lE3oqDImrCLs_2ZmYvkQD78dDHYqL9RM83b8cpkENLwr7Dr6uZcEDzx3BAh_Swik7oTikSnnWZKyZQhu-ngJdpuMo-J9Ia1rr7bjJSh9VIF928j0Z2xcg357szXXRPv2bG34snhSw0J-O40G9gDC66ONbh_spRkRO2EALPI6ivodimUiMeOmYiw2biamtZFB9twNdi2j0cO6tXu1GIV3N-ZhuX49WgnIPLbOTbVJjSYuxyvW7K8e3rjsAay3scA23AoibLbpIyOkNaDg7PtSy_OYCzZpr9WFsny-9ZWG9rjt7PD7MFDBivQ-gcX9C8ypIIBrV2RnWF645Q7t9LCAcJqIKS4-ZGyhpjUpKqX1msM6UQUyLSBbi7G0e_5XwDb0bK31OjlVSoWxvUBPt0pMISAN55wmKxXZMycIZLy2gL7TQKtpOuzjKifw4CxiNBuCs1GKvyKgFs86_zU80Yv1fiErsn09EMCG-vjKy_XGSmznDO7W4WEa3nWihmC09EV00gUmIfRjruKo_2hppzsUQTqfSbsi4J4NsXjzPd8MdfGk7ft4_B1Jw7b3xIvzAYEtZU4t3mXm19F0L8fhtrWNeFwAKqj7r2Sv7T5iIq3xkYHzX4Y04C1XzLt4f3NRRT14rqL5PLGeyw_3-IoPs0HAJi4EZlSoKVTS86wGJTI4QPMThuoh9ehr5Wk5YGRssVtL8FRKsK7hHMdyezQ23YP_-ORnNDo8kYEOtf8LwT7GTG_gBW2a6qncEfYlRqR38oU4VMKiILcm72EveWkhbbPeirncwHEvq99IeDF9uheCMzkkbXr8dV1ATfu2zU77B0nmI4ThVeHi39464k2rubcKfJxO6uCxrGwqb7bgpqw8WMhwXYE2p2hcizm2OjJdhHwz4mH4M32ZAIhzOskJdcnFIi3AIV3uoBWT-u0M7TYxCrPeDa0js2guLqk2aOmjcdrJ-RFEcWoh3wy6dfC5UYy19iGsd_n90UpAcriNh3aIRKKjQyUW5a6YFrrvTmyz8gG-nYOhYjat4i_uNSvuoD0UAb-ZjPTvKVwFtHU0Od5IsLMqpX18NRkAQn76gkC2AUCm6s9lHWXn2l89Lk0ovPhO-hsDbia7KKVl4HkvLm9xEoE63AH5a-iVzHa4vLmeTjuxYmQ9ePTRwsp--saGu0uE5ihA51vmIloZNiPFbD6_RjSbjiYmNutj5Oiw7iXgOdQD_xBJdKtkngn8vDS5XEyxeeSu-_Y8EcUCM7eCyf7HBO0ihelc7epdEzWqxyl7_om0VAbh6XJnbKdnuO6man7agvHUCTxhpN1Dunk19dGF9nnko7g5f9CCArQyRA98iMqna4Fjl--uGJk8Jgfks7TH-lGN7WgzJmLhrzxga609GApyXY3womBSxTGwPP2fgPCypW59uD3RAcI7dc7DdIhDJm1Br1bgI9nf-yMJKTb_i3vcRKurf24iamSwZu6sOBpGvxuBdO_tHMW99vOxmY_wOyfssvS6XUwAen0NQLcHTemmTGEX5uXeEHOkB2g9dUq-XgUrqnzlZmxr9iApb_bWzvsYyvYiZd2As78z_J7DtLStZfRx8FLHR_Q-y8S_wsrkI0XuHmJpUZZ2JgYlerdB8hfE7mHzYeSvaL8obOz2ngJ3G4P2Ia1TDPO8c7qYDnjyY-97uDzUxw_18EEA_g6N6SsO6hup6Nbb_6YO4vx2DjvfCq0ovaziJGO5YCig_JyHddaCMmhknQq0fvK1nkR_NKwj9Hm11kqE_z9CBbRDhernxmYcbyPZkL_swCx5v450VUjkIDKoa6xpsGrj6_AXiT_XTXbhp59NcXzyt1xMtP-krnGyM94Lgr2yQo59wELqo0ejHaciHlh-JMQkNnlJPNyN7mu_56DjJ_yjKW-7mkBwVkEw5SwVh7qwN3xcCjy2LKcxNDDQgoL2uEpMfICLqS8E5R2t4hpWN-nKqT51ADmdjuWmua1i7Wd6p6Yke98HsR2M8S-p2sM4PH_72cuztGwlszo9FsAH9PANQLzIx-LqgC0bqqlRUjOiCSu0OMb72cWlZPGuYKyv_SYiY3IawLrfwfvjpNYKdnE-tVgKPj4sons9-90NSDI3TEy7AMyiYoHtWqyrXBd9JMglevxOsdSGbeP04K8tbDcnJef20I11WIK6qmvdgPL5d_YehDHxKa648zxXx0yy_kxHPEBKqSoAZ9Vh6RmUMuWPYbZyCrJWjmbu_-Fu4mv_r2HkO1nDPh9E_-FuHch6MzexXIj8PixqMLSxX0LC-f6JBPGFBCOiAWlS529RVrapx2F18QNzVw0uI_2kIuVg9Wbg77FTQXaVSHKla9XMtnf3_1cHcXhjLbr989TPTzqzis_yyoUhboailaymlxa2o86jf_hA9lyGIqi1LWcuJDKupaRzWEH2VAx05aUbxDO1PvsWinA_p2mwOv0RCAB6N41OekXH6mEDKVIpLpHbcqUArPp0grqTxuTotOVloyT4ZyinddjO9pTAvuHrFwj0vn17HIbws28uuXjz2cjN8TZMRTkOg2LlRy1TJiDWU39uTuY39M_wl0ZkIXGn4mImNWji6rsTRvHbxfooL5TA8349v5zM8_ZuI__291fMzbY2CIk7SMovasYmFe3mkZ6_osKltjlCO5YC6-A7pu8kI7mg7G_yEUG7GIG8aqGWhXn-fXKcD3s7JmHyfTTXyYh-NsGHvIDIZG-Go1ygIRdSNg",
                        Description = "1830 год. Отставного констебля Лэндора нанимают для расследования смерти курсанта военной академии Вест-Пойнт. Парня нашли повешенным, а когда перенесли в лазарет, кто-то вырезал у него сердце. Осмотрев тело и место повешения, Лэндор приходит к выводу, что бедолага умер насильственной смертью, когда в помощники ему вызывается кадет Эдгар Аллан По — молодой человек острого ума и исключительной наблюдательности.",
                        Rating = 0,
                        Year = 2022,
                        Url = "https://vk.com/video_ext.php?oid=-138993550&id=456244028&hash=538827d380c6d344",
                        Tagline = "Every Heart Tells a Tale",
                        Director = "Скотт Купер",
                        Screenwriter = "Скотт Купер, Луис Байард",
                        Producer = "Кэри Андерсон, Кристиан Бэйл, Луис Байард",
                        Videographer = "Масанобу Такаянаги",
                        Composer = "Говард Шор",
                        Drawer = "Стефания Челла, Майкл Е. Голдман, Трой Сайзмор",
                        Montage = "Дилан Тиченор",
                        Budget = 72000000,
                        Premier = new DateOnly(2022, 12, 14),
                        Age = 16
                    },
                    new Movie{
                        Name = "Кто я",
                        Genres=new List<Genre>{genres[14],genres[6],genres[5],genres[4],genres[3]},
                        Cover = "https://www.kinopoisk.ru/2Q9X2l433/bb8ddck78/N_X8OoJjt-peYhJ2UgbfnTRWBWQX_45FbEK7d0dFbKtnBrZWK6OpQIhyRvFtMplVcxcBF7wnliiZtjdNg1dijQb96TPXHp-LNxNqB2obu5UxZlgZV6f3ZDVSzzoyKBAXp6Z-8-M7VeAIw8PoUArAGDJKABLNXoIU_e8yhDcHt_DTKdBuzv-SgtIS865mkm_pEAf5EIeOJsEcA2cT_12cW4vGWvd72w1c2OMj9Mj_SKiazhAe6VJyDWEb4uhGx_tIA3lE3oqDImrCLs_2ZmYvkQD78dDHYqL9RM83b8cpkENLwr7Dr6uZcEDzx3BAh_Swik7oTikSnnWZKyZQhu-ngJdpuMo-J9Ia1rr7bjJSh9VIF928j0Z2xcg357szXXRPv2bG34snhSw0J-O40G9gDC66ONbh_spRkRO2EALPI6ivodimUiMeOmYiw2biamtZFB9twNdi2j0cO6tXu1GIV3N-ZhuX49WgnIPLbOTbVJjSYuxyvW7K8e3rjsAay3scA23AoibLbpIyOkNaDg7PtSy_OYCzZpr9WFsny-9ZWG9rjt7PD7MFDBivQ-gcX9C8ypIIBrV2RnWF645Q7t9LCAcJqIKS4-ZGyhpjUpKqX1msM6UQUyLSBbi7G0e_5XwDb0bK31OjlVSoWxvUBPt0pMISAN55wmKxXZMycIZLy2gL7TQKtpOuzjKifw4CxiNBuCs1GKvyKgFs86_zU80Yv1fiErsn09EMCG-vjKy_XGSmznDO7W4WEa3nWihmC09EV00gUmIfRjruKo_2hppzsUQTqfSbsi4J4NsXjzPd8MdfGk7ft4_B1Jw7b3xIvzAYEtZU4t3mXm19F0L8fhtrWNeFwAKqj7r2Sv7T5iIq3xkYHzX4Y04C1XzLt4f3NRRT14rqL5PLGeyw_3-IoPs0HAJi4EZlSoKVTS86wGJTI4QPMThuoh9ehr5Wk5YGRssVtL8FRKsK7hHMdyezQ23YP_-ORnNDo8kYEOtf8LwT7GTG_gBW2a6qncEfYlRqR38oU4VMKiILcm72EveWkhbbPeirncwHEvq99IeDF9uheCMzkkbXr8dV1ATfu2zU77B0nmI4ThVeHi39464k2rubcKfJxO6uCxrGwqb7bgpqw8WMhwXYE2p2hcizm2OjJdhHwz4mH4M32ZAIhzOskJdcnFIi3AIV3uoBWT-u0M7TYxCrPeDa0js2guLqk2aOmjcdrJ-RFEcWoh3wy6dfC5UYy19iGsd_n90UpAcriNh3aIRKKjQyUW5a6YFrrvTmyz8gG-nYOhYjat4i_uNSvuoD0UAb-ZjPTvKVwFtHU0Od5IsLMqpX18NRkAQn76gkC2AUCm6s9lHWXn2l89Lk0ovPhO-hsDbia7KKVl4HkvLm9xEoE63AH5a-iVzHa4vLmeTjuxYmQ9ePTRwsp--saGu0uE5ihA51vmIloZNiPFbD6_RjSbjiYmNutj5Oiw7iXgOdQD_xBJdKtkngn8vDS5XEyxeeSu-_Y8EcUCM7eCyf7HBO0ihelc7epdEzWqxyl7_om0VAbh6XJnbKdnuO6man7agvHUCTxhpN1Dunk19dGF9nnko7g5f9CCArQyRA98iMqna4Fjl--uGJk8Jgfks7TH-lGN7WgzJmLhrzxga609GApyXY3womBSxTGwPP2fgPCypW59uD3RAcI7dc7DdIhDJm1Br1bgI9nf-yMJKTb_i3vcRKurf24iamSwZu6sOBpGvxuBdO_tHMW99vOxmY_wOyfssvS6XUwAen0NQLcHTemmTGEX5uXeEHOkB2g9dUq-XgUrqnzlZmxr9iApb_bWzvsYyvYiZd2As78z_J7DtLStZfRx8FLHR_Q-y8S_wsrkI0XuHmJpUZZ2JgYlerdB8hfE7mHzYeSvaL8obOz2ngJ3G4P2Ia1TDPO8c7qYDnjyY-97uDzUxw_18EEA_g6N6SsO6hup6Nbb_6YO4vx2DjvfCq0ovaziJGO5YCig_JyHddaCMmhknQq0fvK1nkR_NKwj9Hm11kqE_z9CBbRDhernxmYcbyPZkL_swCx5v450VUjkIDKoa6xpsGrj6_AXiT_XTXbhp59NcXzyt1xMtP-krnGyM94Lgr2yQo59wELqo0ejHaciHlh-JMQkNnlJPNyN7mu_56DjJ_yjKW-7mkBwVkEw5SwVh7qwN3xcCjy2LKcxNDDQgoL2uEpMfICLqS8E5R2t4hpWN-nKqT51ADmdjuWmua1i7Wd6p6Yke98HsR2M8S-p2sM4PH_72cuztGwlszo9FsAH9PANQLzIx-LqgC0bqqlRUjOiCSu0OMb72cWlZPGuYKyv_SYiY3IawLrfwfvjpNYKdnE-tVgKPj4sons9-90NSDI3TEy7AMyiYoHtWqyrXBd9JMglevxOsdSGbeP04K8tbDcnJef20I11WIK6qmvdgPL5d_YehDHxKa648zxXx0yy_kxHPEBKqSoAZ9Vh6RmUMuWPYbZyCrJWjmbu_-Fu4mv_r2HkO1nDPh9E_-FuHch6MzexXIj8PixqMLSxX0LC-f6JBPGFBCOiAWlS529RVrapx2F18QNzVw0uI_2kIuVg9Wbg77FTQXaVSHKla9XMtnf3_1cHcXhjLbr989TPTzqzis_yyoUhboailaymlxa2o86jf_hA9lyGIqi1LWcuJDKupaRzWEH2VAx05aUbxDO1PvsWinA_p2mwOv0RCAB6N41OekXH6mEDKVIpLpHbcqUArPp0grqTxuTotOVloyT4ZyinddjO9pTAvuHrFwj0vn17HIbws28uuXjz2cjN8TZMRTkOg2LlRy1TJiDWU39uTuY39M_wl0ZkIXGn4mImNWji6rsTRvHbxfooL5TA8349v5zM8_ZuI__291fMzbY2CIk7SMovasYmFe3mkZ6_osKltjlCO5YC6-A7pu8kI7mg7G_yEUG7GIG8aqGWhXn-fXKcD3s7JmHyfTTXyYh-NsGHvIDIZG-Go1ygIRdSNg",
                        Description = "Аутсайдер Бенджамин решает добиться уважения в среде хакеров. Дерзкий немецкий хит в духе «Бойцовского клуба»",
                        Rating = 0,
                        Year = 2014,
                        Url = "https://vk.com/video_ext.php?oid=-138993550&id=456243307&hash=71e0c037b9cafb3a",
                        Tagline = "Каждый видит то, что хочет видеть",
                        Director = "Баран бо Одар",
                        Screenwriter = "Янтье Фризе, Баран бо Одар",
                        Producer = "Квирин Берг, Макс Видеман, Shabuddin Choudhary",
                        Videographer = "Николос Суммерер",
                        Composer = "Михаэль Камм",
                        Drawer = "Силке Бур, Маркус Нордеманн, Рамона Клиниковски",
                        Montage = "Роберт Жесач",
                        Collected = 7700259,
                        Premier = new DateOnly(2014,9,6),
                        Age = 18
                    }
                };
                movies.ToList().ForEach(movie => context.Movies.Add(movie));
                await context.Reviews.AddRangeAsync(new Review[]
                {
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Отличный фильм, рекомендую всем!", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Наивное кино, не стоит тратить время", Rating = 2 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Прекрасная игра актеров, захватывающий сюжет", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм оставил равнодушным, ничего особенного", Rating = 2.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Я в восторге! Лучший фильм всех времен!", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Сюжет предсказуем, но смотреть было не скучно", Rating = 3.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Отстой, полный бред!", Rating = 1 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Захватывающий экшен, один из лучших фильмов в этом жанре", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Понравился финал, неожиданный поворот событий", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Нудный фильм, сюжет не цепляет", Rating = 2 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Отличное кино, смотрела на одном дыхании", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Глубокий смысл, много мыслей после просмотра", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Потрясающая игра актеров, очень трогательная история", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм вызвал у меня множество эмоций, рекомендую!", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Увлекательный сюжет, непредсказуемый повороты", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм сомнительного качества, жаль потраченного времени", Rating = 2 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Очень понравился, захватывающая драма", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм, который меня расстроил, ожидал большего", Rating = 2.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Смешно и трогательно, отличная комедия", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Наигранно и нереалистично, не понравилось", Rating = 2 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм, который зацепил и заставил задуматься", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Не рекомендую, пустая трата времени", Rating = 1.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Интересный сюжет, рекомендую для просмотра", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм с глубоким смыслом, отличная работа режиссера", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Идеальный фильм, все балансирует на отличном уровне", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Необычная история, захватывающая драма", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм полный магии, смотрела с удовольствием", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Сюжет неинтересный, фильм не зацепил", Rating = 2 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм вызвал бурю эмоций, я в восторге!", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Захватывающая история, отличное исполнение", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Плохой фильм, разочарована", Rating = 1.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Интригующий сюжет, качественный фильм", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм, который вызвал массу эмоций, настоящее произведение искусства", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Сюжет непредсказуем, переживала за главных героев", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Расстроенный фильм, не понял его смысла", Rating = 1.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Отличная атмосфера, красивое кино", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм, который меня поразил, не забуду никогда", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Сюжет нудноват, но фильм в целом хороший", Rating = 3 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм вызвал глубокие эмоции, просто потрясающе", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Захватывающий фильм, смотрел на одном дыхании", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Пустая трата времени, не рекомендую", Rating = 2 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм, который зацепил с первых минут", Rating = 4.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Не понравился фильм, ничего особенного", Rating = 2.5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Качественное кино, прекрасно отыгранные роли", Rating = 4 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Идеальный фильм, захватывающая драма", Rating = 5 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм с интересным сюжетом, но не зацепил", Rating = 3 },
                    new Review { movie = movies[0], user = context.Users.First(), Text = "Фильм, который вызвал у меня множество эмоций!", Rating = 5 }
                });

                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
