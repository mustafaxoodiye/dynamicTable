import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SubHeadService {

  baseUrl = "http://localhost:5050/api/";
  headers = { 'content-type': 'application/json'}
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getSubHeadConfigs(subHead:string){
    return this.http.get<SubHeadConfig>(
      this.baseUrl + "SubHeadConfigs/" + subHead,
      {'headers':this.headers});
  }
}

export class SubHeadConfig {
  id: number;
  subHeadId: string;
  metaData: SubHeadMetaData[] = [];

  constructor(id: number, subHeadId: string, metaData: SubHeadMetaData[] = []) {
    this.id = id;
    this.subHeadId = subHeadId;
    this.metaData = metaData;
  }
}

export class SubHeadMetaData {
  key: string;
  displayName: string;
  type: string;

  constructor(key: string, displayName: string, type: string) {
    this.key = key;
    this.displayName = displayName;
    this.type = type;
  }
}

