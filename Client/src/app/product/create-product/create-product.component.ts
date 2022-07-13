import { Component, OnInit } from '@angular/core';
import { FormControl, FormControlName, FormGroup } from '@angular/forms';
import { GeneralService } from 'src/app/services/general.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss'],
})
export class CreateProductComponent implements OnInit {
  productForm!: FormGroup;
  constructor(private gService: GeneralService) {}

  ngOnInit(): void {
    this.productForm = new FormGroup({
      Name: new FormControl('', []),
      Description: new FormControl('', []),
      Price: new FormControl(0, []),
      Picture: new FormControl('', []),
      Type: new FormControl('', []),
      Brand: new FormControl('', []),
      QuantityInStock: new FormControl(1, []),
    });
  }

  onSubmit() {

    if (!this.productForm.valid) {
      return
    }

    var f = new FormData();

    for (const key in this.productForm.value) {
      if (Object.prototype.hasOwnProperty.call(this.productForm.value, key)) {
        const element = this.productForm.value[key];
        f.set(key, element)
      }
    }
    
    this.gService.httpPost('product/create', f).subscribe(res=>{

    })
  }

  onChange(e: any) {
    this.productForm.patchValue({ Picture: e.target.files[0] });
  }
}
