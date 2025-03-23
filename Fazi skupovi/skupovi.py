def Interval_Interval():
    Amin = float(input("Unesite Amin (0 do 1): "))
    Amax = float(input("Unesite Amax (0 do 1): "))
    Bmin = float(input("Unesite Bmin (0 do 1): "))
    Bmax = float(input("Unesite Bmax (0 do 1): "))

    if Amin == Amax or Bmin == Bmax:
        print("Amin i Amax ili Bmin i Bmax ne smeju biti jednaki!")
        return

    # Sortiranje vrednosti u neopadajući niz
    values = sorted([Amin, Amax, Bmin, Bmax])
    a1, a2, a3, a4 = values

    # Logika za ispis Y
    if (Amin <= Amax and Bmin < Bmax) or (Amin < Amax and Bmin >= Bmax):
        if a2 == Amin and a3 == Amax and a1 == Bmin and a4 == Bmax:
            print(f"Y = [{a1}, {a3}]")
        elif a2 == Amin and a4 == Amax and a1 == Bmin and a3 == Bmax:
            print(f"Y = [{a1}, {a3}]")
        elif a3 == Amin and a4 == Amax and a1 == Bmin and a2 == Bmax:
            print(f"Y = [{a1}, {a2}]")
        else:
            print("Y je prazan skup.")
    else:
        print("Y je prazan skup.")


def Interval_Skup():
    Amin = float(input("Unesite Amin (0 do 1): "))
    Amax = float(input("Unesite Amax (0 do 1): "))

    if Amin == Amax:
        print("Amin i Amax ne smeju biti jednaki!")
        return

    B = list(map(float, input("Unesite elemente niza B (0 do 1) odvojene razmakom: ").split()))

    # Sortiranje niza B i uklanjanje duplikata
    B = sorted(set(B))
    
    Y = []

    # Dodavanje elemenata u Y na osnovu uslova
    for element in B:
        if Amin >= element:
            Y.append(element)

    # Ispis rezultata
    print(f"Traženi skup Y = {{{', '.join(map(str, Y))}}}")


def Skup_Skup():
  
    # Unos dva niza decimalnih brojeva
    niz_A = list(map(float, input("Unesi niz A (brojevi od 0 do 1, odvojeni razmacima): ").split()))
    niz_B = list(map(float, input("Unesi niz B (brojevi od 0 do 1, odvojeni razmacima): ").split()))

    # Sortiranje i uklanjanje duplikata iz niza A i B
    niz_A = sorted(set([x for x in niz_A if 0 <= x <= 1]))
    niz_B = sorted(set([x for x in niz_B if 0 <= x <= 1]))
    
    # Setovanje praznih nizova
    Y, Y1, Y2, Y3, Y4, Y5, Y6 = [], [], [], [], [], [], []
    Y5min, Y5max = None, None
    # Minimalne i maksimalne vrednosti
    if len(niz_A) == 0 or len(niz_B) == 0:
        print("Jedan od skupova je prazan.")
        return

    Amin, Amax = min(niz_A), max(niz_A)
    Bmin, Bmax = min(niz_B), max(niz_B)

    # Provera uslova
    if Amin < Bmin:
        print("Y je prazan skup")
        return

    # Popunjavanje nizova Y1-Y6
    for element in niz_B:
        if element in niz_A:
            Y1.append(element)

        if element in niz_A and Amin < element < Amax and element < Bmax:
            Y2.append(element)

        if Amin < element < Bmin:
            Y3.append(element)

        if Amax < element < Bmax:
            Y4.append(element)

    for element in niz_A:
        if element > Bmax:
            Y6.append(element)
        if element in niz_A and element not in niz_B:
            Y5.append(element)

    # Dodavanje Bmin i Bmax
    if Y3:
        Y3.append(Bmin)
    if Y4:
        Y4.append(Bmax)

    # Y5 min i max vrednosti
    if Y5:
        Y5min, Y5max = min(Y5), max(Y5)
    else:
        Y5min, Y5max = None, None

    # Nova poredjenja
    if Y6:
        if Y3:
            if not Y2 and not Y5:
                Y = sorted(Y3 + Y1)
                print(format_output(Y))

            if Y2 and not Y5:
                Y = sorted(Y3 + Y1)
                print(format_output(Y))

            if Y5:
                for element in niz_A:
                    if element < Y5min:
                        Y.append(element)
                Y += Y3
                print(format_output(sorted(Y)))

        elif not Y3 and not Y4:
            if not Y5:
                print(format_output(niz_B))
            else:
                for element in niz_B:
                    if element < Y5min:
                        Y.append(element)
                print(format_output(sorted(Y)))
    if Amin == Bmin and Amax == Bmax:
        if not Y5:
	        if 1 in niz_B:
	            print(format_output(niz_B))
	        else:
	            print(format_output(niz_B))
	            print("U")
	            print("(", Bmax, ",", 1, "]")
        else:
            for element in niz_B:
                if element < Y5min:
                    Y.append(element)
            print(format_output(sorted(Y)))

    if Amin > Bmin and Amax < Bmax:
        if not Y5:
            print(format_output(niz_A))
            print("U")
            print("(", Amax, ",", 1, "]")
        else:
            for element in niz_B:
                if element < Y5min:
                    Y.append(element)
            print(format_output(sorted(Y)))

    if (Amin == Bmin and Bmax > Amax):
        if not Y5:
            print(format_output(niz_A))
            print("U")
            print("(", Amax, ",", 1, "]")
        else:
            for element in niz_B:
                if element < Y5min:
                    Y.append(element)
            print(format_output(sorted(Y)))
    if(Amin > Bmin and Amax == Bmax):
	    if not Y5:
	        print(format_output(niz_B))
	    else:
	        for element in niz_B:
	            if element < Y5min:
	                Y.append(element)
	        print(format_output(sorted(Y)))


# Funkcija za formatiranje ispisa
def format_output(lista):
    # Zamenjuje uglaste zagrade sa vitičastim i "*1" i "*2" sa "[", "]"
    return str(lista).replace('[', '{').replace(']', '}')

def main():
    print("Odaberite funkciju:")
    print("1. Interval_Interval")
    print("2. Interval_Skup")
    print("3. Skup_Skup")

    choice = input("Unesite broj funkcije (1-3): ")

    if choice == '1':
        Interval_Interval()
    elif choice == '2':
        Interval_Skup()
    elif choice == '3':
        Skup_Skup()
    else:
        print("Nevalidan izbor!")


if __name__ == "__main__":
    main()
