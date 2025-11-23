import { Component, OnInit } from '@angular/core';
import { EstimationService } from '../services/estimation.service';
import { ReportService, VehicleDetails } from '../services/report.service';

@Component({
  selector: 'app-estimation',
  templateUrl: './estimation.component.html',
  styleUrls: ['./estimation.component.scss']
})
export class EstimationComponent implements OnInit {

  brands: any[] = [];
  models: any[] = [];
  subModels: any[] = [];
  years: number[] = [];
  colors: string[] = ["Red", "Black", "White", "Silver", "Blue", "Grey"];

  selectedBrandName: string = '';
  selectedModelName: string = '';
  selectedSubModelName: string = '';

  form: any = {
    brandId: '',
    modelId: '',
    subModelId: '',
    year: '',
    color: '',
    customer: ''
  };

  estimationResult: any = null;
  vehicleDetails!: VehicleDetails;

  constructor(private estimationService: EstimationService, private reportService :  ReportService) {}

  ngOnInit(): void {
    this.loadBrands();
    const currentYear = new Date().getFullYear();
    for (let y = 1970; y <= currentYear; y++) {
      this.years.push(y);
    }
  }

  loadBrands() {
    this.estimationService.getBrands().subscribe(data => {
      this.brands = data;
    });
  }

  onBrandChange() {
    const selected = this.brands.find(b => b.id == this.form.brandId);
    this.selectedBrandName = selected ? selected.name : '';

    this.models = [];
    this.subModels = [];
    this.form.modelId = '';
    this.form.subModelId = '';
    this.selectedModelName = '';
    this.selectedSubModelName = '';

    if (this.form.brandId) {
      this.estimationService.getModels(this.form.brandId).subscribe(data => {
        this.models = data;
      });
    }
  }

  onModelChange() {
    const selected = this.models.find(m => m.id == this.form.modelId);
    this.selectedModelName = selected ? selected.name : '';

    this.subModels = [];
    this.form.subModelId = '';
    this.selectedSubModelName = '';

    if (this.form.modelId) {
      this.estimationService.getSubModels(this.form.modelId).subscribe(data => {
        this.subModels = data;
      });
    }
  }

  onSubModelChange() {
    const selected = this.subModels.find(s => s.id == this.form.subModelId);
    this.selectedSubModelName = selected ? selected.name : '';
  }

  onCalculate() {
    if (!this.form.brandId || !this.form.modelId || !this.form.subModelId || !this.form.year || !this.form.color) {
      alert('Please fill all required fields');
      return;
    }

    this.estimationService.calculateEstimation(this.form).subscribe(result => {
      this.estimationResult = result;
    });
  }

  onReset(){
    this.form = { brandId: '', modelId: '', subModelId: '', year: '', color: '' };
    this.models = [];
    this.subModels = [];
    this.selectedBrandName = this.selectedModelName = this.selectedSubModelName = '';
    this.estimationResult = null;
  }

  downloadExcel(){
    this.createVehicleDetails();
    this.reportService.generateExcel(this.vehicleDetails).subscribe(blob => {
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `VehicleImportQuote_${new Date().getTime()}.xlsx`;
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }

  downloadPdf(){
    this.createVehicleDetails();
    this.reportService.generatePdf(this.vehicleDetails).subscribe(blob => {
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `VehicleImportQuote_${new Date().getTime()}.pdf`;
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }

  createVehicleDetails(){
    this.vehicleDetails =  
    {
      customer: this.form.customer,
      brand: this.selectedBrandName,
      model: this.selectedModelName,
      subModel: this.selectedSubModelName,
      fuelType: this.estimationResult.fuelType,
      engineCapacity: this.estimationResult.engineCapacity,
      chassisId: this.estimationResult.chassisId,
      color: this.form.color,
      year: this.form.year,
      cifJPY: this.estimationResult.ciF_JPY,
      exchangeRate: this.estimationResult.exchangeRate,
      cifLKR: this.estimationResult.ciF_LKR,
      totalDuty: this.estimationResult.totalDuty,
      clearingCharges: this.estimationResult.clearingCharges,
      bankDocCharge: this.estimationResult.bankDocCharge,
      deliveryCharges: this.estimationResult.deliveryCharges,
      totalCost: this.estimationResult.totalCost
    };
  }
}
