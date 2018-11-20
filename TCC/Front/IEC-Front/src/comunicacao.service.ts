import { Http } from '@angular/http'
import { Injectable } from '@angular/core'
import { Localizacao } from './shared/localizacao.model'
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ComunicacaoService{

    constructor(private http : Http, private httpClient: HttpClient){}
 
    getLocalizacao(latitude: string, longitude: string) : Promise<Localizacao> {
        return this.http.get(`http://localhost:3000/localizacao?latitude=${latitude}&longitude=${longitude}`)
            .toPromise()
            .then((resposta: any) => resposta.json())
    }
    
    sndLocalizacao (localizacao: Localizacao): void {
      const ParseHeaders = {
        headers: new HttpHeaders({
         'Content-Type'  : 'application/x-www-form-urlencoded'
        })
       };

        let _URL = "http://localhost:3000/sendlocalizacao";
        let FormData = localizacao
        this.httpClient.post(_URL,FormData,ParseHeaders).subscribe((res) => {
        console.log(res);});
    }
}