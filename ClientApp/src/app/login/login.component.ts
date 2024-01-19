import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  senha: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit(): void {
    this.authService.login(this.email, this.senha).subscribe(
      (response : any) => {
        console.log('Autenticação bem-sucedida:', response);

        this.router.navigate(['/cadastro-usuarios']);
      },
      (error : any) => {
        console.error('Erro de autenticação:', error);
      }
    );
  }
}
