import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app.config';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EstimationService {

  constructor(private http: HttpClient, private config: AppConfig) { }

  getBrands(): Observable<any> {
    return this.http.get(`${this.config.apiUrl}/VehicleDetails/brands`);
  }

  getModels(brandId: number): Observable<any> {
    return this.http.get(`${this.config.apiUrl}/VehicleDetails/models/${brandId}`);
  }

  getSubModels(modelId: number): Observable<any> {
    return this.http.get(`${this.config.apiUrl}/VehicleDetails/submodels/${modelId}`);
  }

  calculateEstimation(form: any): Observable<any> {
    return this.http.post(`${this.config.apiUrl}/Estimation/calculate`, form);
  }
}
