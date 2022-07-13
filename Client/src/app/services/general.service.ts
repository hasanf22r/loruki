import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class GeneralService {
  constructor(
    private http: HttpClient,
    @Inject('baseUrl') private baseUrl: string,
    private toastr: ToastrService
  ) {}

  httpGet<T>(url: string, obj: {}) {
    return this.http.get<T>(this.baseUrl + url, { params: obj });
  }

  httpPost<T>(url: string, obj: {}) {
    return this.http.post<T>(this.baseUrl + url, obj);
  }

  successToast(msg: string) {
    this.toastr.success(msg);
  }

  errorToast(msg: string) {
    this.toastr.error(msg);
  }

  infoToast(msg: string) {
    this.toastr.info(msg);
  }
}
