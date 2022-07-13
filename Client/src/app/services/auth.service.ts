import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public getToken(): string {
    var token = localStorage.getItem('token')
    if (typeof token === 'string') {
      return token;
    }
    return '';
  }
}