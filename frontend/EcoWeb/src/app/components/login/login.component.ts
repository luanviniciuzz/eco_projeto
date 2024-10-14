import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CardModule,
    InputTextModule,
    FormsModule,
    PasswordModule,
    ButtonModule,
    RouterLink,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  login = {
    nome: '',
    senha: '',
  };

  private authService = inject(AuthService);
  private router = inject(Router);

  onLogin() {
    const { nome, senha } = this.login;
    this.authService.getUserDetails(nome, senha).subscribe({
      next: (response) => {
        if (response.dados) {
          sessionStorage.setItem('token', response.dados);
          this.router.navigate(['home']);
        } else {
          console.log('erro login')
        }
      },
      error: (e) => {
        console.log(e)
      },
    });
  }
}
