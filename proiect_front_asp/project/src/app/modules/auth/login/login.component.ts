import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForma: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private dataService: DataService,
  ) { }

//getters
  /*get username(): AbstractControl {
    return this.loginForma.get('username');
  }

  get password(): AbstractControl {
    return this.loginForma.get('password');
  }*/

  ngOnInit(): void {
  }

  public login(): void{
    console.log(this.loginForma.value);
    this.dataService.changeUserData(this.loginForma.value);
    localStorage.setItem('Role', 'Admin');

    this.router.navigate(['']);
  }

}
