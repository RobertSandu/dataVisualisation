module app.Licenta.Exemple {

    export class Persoana {

        //campurile unei clase pot sa fie declarate direct ca parametrii ai constuctorului
        //si compilatorul le va atribui
        constructor(private anulNasterii: number, private lunaNasterii: number, private ziuaNasterii: number) {}

        get anNastere(): number {

            return this.anulNasterii;

        }

        get lunaNastere(): number {

            return this.lunaNasterii;

        }

        get ziuaNastere(): number {

            return this.ziuaNasterii;

        }

        get dataNasterii(): string {

            return this.ziuaNasterii + '-' + this.lunaNasterii + '-' + this.anulNasterii;

        }

    }

    export interface ICetatean {

        tara: string;
        nume: string;

    }

    export class Cetatean extends Persoana implements ICetatean {

        //campurile pot sa fie declarate si separat
        tara: string;
        nume: string;

        constructor(anulNasterii: number, lunaNasterii: number, ziuaNasterii: number, tara: string, nume: string) {

            super(anulNasterii, lunaNasterii, ziuaNasterii);

            this.tara = tara;
            this.nume = nume;

        }

    }

    // se poate specifica tipul variabilei folosind sintaxa numeVariabila: tipVariabila
    var Mircea: Cetatean = new Cetatean(1982, 11, 10, 'Romania', 'Mircea');

    // sau compilatorul poate infera tipul variabilei din cod
    var Mirel = new Cetatean(1982, 11, 10, 'Romania', 'Mirel');

}


var ceva = new Promise<string>(function(resolve, reject): void{

});