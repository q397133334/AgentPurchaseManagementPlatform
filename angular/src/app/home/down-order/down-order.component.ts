import { Component, OnInit, Injector, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import * as moment from 'moment';

import { OrderServiceProxy, DownOrderDto, DownOrderDtoState } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'down-order-modal',
  templateUrl: './down-order.component.html',
  styleUrls: ['./down-order.component.css']
})
export class DownOrderComponent extends AppComponentBase implements OnInit {

  @ViewChild('downOrderModal') downOrderModal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  public active = false;
  public saving = false;
  public order: DownOrderDto;
  public arrivalDateTime: string;

  constructor(
    private injector: Injector,
    private _orderServiceProxy: OrderServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {

  }
  show(id): void {
    this._orderServiceProxy.getDownOrder(id)
      .subscribe(result => {
        this.order = result;
        // this.arrivalDateTime = this.order.arrivalDateTime.format('YYYY-MM-DD');
        // if (this.arrivalDateTime.indexOf('0001') > -1) {
        //   this.arrivalDateTime = '';
        //   this.order.arrivalDateTime = null;
        // }
        this.active = true;
        this.downOrderModal.show();
      })
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    const _this = this;
    $(this.modalContent.nativeElement).find('.datetimepicker').datetimepicker({
      format: 'yyyy-mm-dd',
      language: 'zh-CN',
      autoclose: true,
      minView: 2
    }).on('changeDate', function (ev) {
      console.log(ev);
      // _this.order.arrivalDateTime = moment(ev.date);
      _this.arrivalDateTime = ev.currentTarget.value;
      ev.currentTarget.focus();
      ev.currentTarget.blur();
    });
  }

  save(): void {
    this.saving = true
    this._orderServiceProxy.downOrder(this.order)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
      });
  }

  close(): void {
    this.active = false;
    this.downOrderModal.hide();
  }
}
