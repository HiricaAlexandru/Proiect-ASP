import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {

  public url = 'https://localhost:44377/api/Model/get-all-models-text';
  constructor(
    public http: HttpClient
  ) { }

  public getAllModels(): Observable<any>{
    return this.http.get(this.url);
  }

}
