import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';
import { ModelsService } from 'src/app/services/models.service';

@Component({
  selector: 'app-modele',
  templateUrl: './modele.component.html',
  styleUrls: ['./modele.component.scss']
})
export class ModeleComponent implements OnInit, OnDestroy {

  public subscription: Subscription;
  public loggedUser;
  public models = [];
  public displayedColumns = ['id','nameprod','name'];

  constructor(
    private router: Router,
    private dataService: DataService,
    private ModelsService: ModelsService,
    
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser=user);
    this.ModelsService.getAllModels().subscribe(
      (result)=>{
        console.log(result);
        this.models = result;
      },
      (error)=>{
        console.error(error);
      }
    );
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  public logout(): void{
    localStorage.setItem('Role','Anonim');
    this.router.navigate(['/login']);
  }

}
