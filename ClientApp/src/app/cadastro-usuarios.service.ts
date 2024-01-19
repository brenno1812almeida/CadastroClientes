import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CadastroService {
  private apiUrl = 'https://localhost:7225/api';

  constructor(private http: HttpClient) { }

  cadastrarUsuario(usuarioData: FormData): Observable<any> {
    return this.http.post(`${this.apiUrl}/cadastro-usuarios`, usuarioData);
  }
}
