import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

 readFromLocalStorage(key:string) {
  if (localStorage.getItem(key))
  {
     return JSON.parse(localStorage.getItem(key) || '{}');
  }
  else {
    return null;
  }
}

 writeToLocalStorage(key:string, data:string) {
  localStorage.setItem(key, JSON.stringify(data));
}

 deleteFromLocalStorage(key:string) {
  localStorage.removeItem(key);
}
}
