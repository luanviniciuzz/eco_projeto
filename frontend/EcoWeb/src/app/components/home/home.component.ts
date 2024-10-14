import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ButtonModule, MenubarModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  private router = inject(Router);
  logout() {
    sessionStorage.clear();
    this.router.navigate(['login']);
  }

  items: MenuItem[] | undefined;


  ngOnInit() {
      this.items = [
        {
          label: 'ECO Doções',
          icon: 'pi pi-link',
          command: () => {
              this.router.navigate(['/home']);
          }
        },
          {
              label: 'Área do contribuinte',
              icon: 'pi pi-palette',
              items: [
                  {
                      label: 'Cadastrar contribuinte',
                      route: ''
                  },
                  {
                      label: 'Registrar uma contribuição',
                      route: ''
                  }
              ]
          },
          
          {
              label: 'Mensageiro',
              icon: 'pi pi-home',
              items: [
                  {
                      label: 'Cadastrar um mensageiro',
                      url: ''
                  },
                  {
                      label: 'Movimento diário',
                      url: ''
                  }
              ]
          },
          {
            label: 'Logout',
            icon: 'pi pi-link',
            styleClass: 'bg-purple',
            command: () => {
              sessionStorage.clear();
              this.router.navigate(['login']);
            }
          },
      ];
  }
}
