import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConfig } from '../app.config';

export interface VehicleDetails {
    customer: string;
    brand: string;
    model: string;
    subModel: string;
    fuelType: string;
    engineCapacity: string;
    chassisId: string;
    color: string;
    year: string;
    cifJPY: string;
    exchangeRate: string;
    cifLKR: string;
    totalDuty: string;
    clearingCharges: string;
    bankDocCharge: string;
    deliveryCharges: string;
    totalCost: string;
}

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  constructor(private http: HttpClient, private config: AppConfig) {}

  generateExcel(vehicleDetails: VehicleDetails): Observable<Blob> {
    return this.http.post(`${this.config.apiUrl}/Reports/generate-excel`, vehicleDetails, { responseType: 'blob' });
  }

  generatePdf(vehicleDetails: VehicleDetails): Observable<Blob> {
    return this.http.post(`${this.config.apiUrl}/Reports/generate-pdf`, vehicleDetails, { responseType: 'blob' } );
  }
}
