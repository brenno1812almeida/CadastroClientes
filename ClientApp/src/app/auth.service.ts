import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  private apiUrl = 'https://localhost:7225/api/auth';
  private isAuthenticated: boolean = false;

  constructor(private http: HttpClient) { }

  login(email: string, senha: string): Observable<any> {
    const credentials = { email, password: senha };

    this.isAuthenticated = true;

    return this.http.post(`${this.apiUrl}/login`, credentials);
  }

  isAuthenticatedUser(): boolean {
    return this.isAuthenticated;
  }
}
