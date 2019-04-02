import { Component, OnInit, Injector, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BalanceRecordServiceProxy, CreateBalanceDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'user-balance',
  templateUrl: './user-balance.component.html',
  styleUrls: ['./user-balance.component.css']
})
export class UserBalanceComponent extends AppComponentBase implements OnInit {

  @ViewChild('userBalanceModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;


  active = false;
  saving = false;
  @Output() modalSave: EventEmitter<any> = new EventEmitter();
  balance: CreateBalanceDto;

  constructor(
    injector: Injector,
    private _balanceRecordServiceProxy: BalanceRecordServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {

  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }

  show(id: number): void {
    this.balance = new CreateBalanceDto();
    this.balance.userId = id;
    this.active = true;
    this.modal.show();
  }

  save(): void {
    this.saving = true;
    this._balanceRecordServiceProxy.create(this.balance)
      .pipe(finalize(() => { this.saving = false }))
      .subscribe((result) => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
      });
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

}
