enum Privilegije {
    DODAJ_KOMENTAR = 1,
    OBRISI_KOMENTAR = DODAJ_KOMENTAR << 1,
    DODAJ_LITERATURU = DODAJ_KOMENTAR << 2,
    IZMENI_LITERATURU = DODAJ_KOMENTAR << 3,
    OBRISI_LITERATURU = DODAJ_KOMENTAR << 4,
    DODAJ_PREDMET = DODAJ_KOMENTAR << 5,
    IZMENI_PREDMET = DODAJ_KOMENTAR << 6,
    OBRISI_PREDMET = DODAJ_KOMENTAR << 7,
    DODAJ_BOARD = DODAJ_KOMENTAR << 8,
    OBRISI_BOARD = DODAJ_KOMENTAR << 9,
    DODAJ_BOARD_NOTE = DODAJ_KOMENTAR << 10,
    OBRISI_BOARD_NOTE = DODAJ_KOMENTAR << 11,
    OBRISI_KORISNIKA = DODAJ_KOMENTAR << 12,
    KOMENTAR_ALL = DODAJ_KOMENTAR | OBRISI_KOMENTAR,
    LITERATURA_ALL = DODAJ_LITERATURU | IZMENI_LITERATURU | OBRISI_LITERATURU,
    PREDMET_ALL = DODAJ_PREDMET | IZMENI_PREDMET | OBRISI_PREDMET,
    BOARD_ALL = DODAJ_BOARD | OBRISI_BOARD | DODAJ_BOARD_NOTE | OBRISI_BOARD_NOTE,
    STUDENT = DODAJ_KOMENTAR | DODAJ_LITERATURU | DODAJ_BOARD_NOTE,
    MENTOR = STUDENT | LITERATURA_ALL,
    ADMIN = KOMENTAR_ALL | LITERATURA_ALL | PREDMET_ALL | BOARD_ALL | OBRISI_KORISNIKA

}

export { Privilegije }