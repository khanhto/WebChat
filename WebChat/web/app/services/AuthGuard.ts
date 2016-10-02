import { CanActivate, Router } from '@angular/router';
import { UserContext } from './UserContext';
import {User} from '../models/User';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private userContext: UserContext, private router: Router) {}

  canActivate() {
    return this.userContext
                .getCurrentUser()
                .then(currentUser => {
                    var isAuthenticated = currentUser.isAuthenticated();
                    if (!isAuthenticated) {
                         this.router.navigate(['/login']);
                    }

                    return isAuthenticated;
                });
  }
}