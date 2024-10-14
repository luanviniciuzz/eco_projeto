import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../interfaces/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = 'https://localhost:7170/';
  constructor(private http: HttpClient) {}


  // getUserDetails(): Observable<User[]> {
  //   return this.http.get<User[]>(
  //     `${this.baseUrl}/api/login`
  //   );
  // }
  

  getUserDetails(nome: string, senha: string): Observable<any> {
    const body = { nome, senha };
    return this.http.post<any>(`${this.baseUrl}api/login`,body);
  }
}