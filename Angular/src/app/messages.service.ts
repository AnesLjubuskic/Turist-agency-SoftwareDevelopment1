import { Injectable } from '@angular/core';
import {Subject,Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class MessagesService {
private poruka=new Subject<string>();
  constructor() { }

  public getMessage():Observable<string>{
return this.poruka.asObservable();
  }
  public updateMessage(message:string){
    this.poruka.next(message);
  }
}
