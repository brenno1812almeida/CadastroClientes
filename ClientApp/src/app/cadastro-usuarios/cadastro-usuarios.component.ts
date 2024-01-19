import { Component } from '@angular/core';
import { CadastroService } from '../cadastro-usuarios.service';

@Component({
  selector: 'app-cadastro-usuarios',
  templateUrl: './cadastro-usuarios.component.html',
  styleUrls: ['./cadastro-usuarios.component.css']
})
export class CadastroUsuariosComponent {
  email: string = '';
  senha: string = '';
  username: string = '';
  telefone: string = '';
  imagePreview: File | null = null;
  foto: string | ArrayBuffer | null = null;

  onFileSelected(event: any): void {
    const file = event.target.files[0];

    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.foto = reader.result;
      };
      reader.readAsDataURL(file);
      this.imagePreview = file;
    }
  }

  constructor(private cadastroService: CadastroService) { }

  onSubmitCadastro(): void {
    if (this.imagePreview) {
      const formData = new FormData();
      formData.append('email', this.email);
      formData.append('senha', this.senha);
      formData.append('username', this.username);
      formData.append('telefone', this.telefone);
      formData.append('foto', this.imagePreview);

      this.cadastroService.cadastrarUsuario(formData).subscribe(
        (response) => {
          console.log('Cadastro bem-sucedido:', response);
        },
        (error) => {
          console.error('Erro ao cadastrar usuário:', error);
        }
      );
    }
  }
}
