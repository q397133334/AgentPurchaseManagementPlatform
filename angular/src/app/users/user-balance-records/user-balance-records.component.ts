import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { BalanceDto, BalanceRecordServiceProxy } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'user-balance-records',
  templateUrl: './user-balance-records.component.html',
  styleUrls: ['./user-balance-records.component.css']
})
export class UserBalanceRecordsComponent extends PagedListingComponentBase<BalanceDto> {

  private balances: BalanceDto[] = [];
  private userId = 0;
  public isActive = false

  @ViewChild('userBalanceRecords') userBalanceRecords: ModalDirective

  constructor(
    private injector: Injector,
    private _balanceRecordsServiceProxy: BalanceRecordServiceProxy
  ) {
    super(injector);
  }

  list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._balanceRecordsServiceProxy.getAll(this.userId, request.skipCount, request.maxResultCount)
      .pipe(finalize(() => {
        finishedCallback()
      }))
      .subscribe((result) => {
        this.balances = result.items
      })
  }
  onShown(): void {
    this.refresh();
    this.isActive = true;
  }

  show(userId: number) {
    this.userId = userId;

    this.userBalanceRecords.show();
  }

  close(): void {
    this.isActive = false;
    this.userBalanceRecords.hide()
  }

  delete(): void {

  }
}
