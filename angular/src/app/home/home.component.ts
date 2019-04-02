import { Component, Injector, ViewChild, OnInit, ElementRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { OrderServiceProxy, PagedResultDtoOfOrderListDto, OrderListDto, OrderType } from 'shared/service-proxies/service-proxies';
import { CreateOrderComponent } from './create-order/create-order.component';
import { EditOrderComponent } from './edit-order/edit-order.component';
import { DownOrderComponent } from './down-order/down-order.component';
import * as moment from 'moment';
import { AddOtherdescComponent } from './add-otherdesc/add-otherdesc.component';
import { AppConsts } from '@shared/AppConsts';

@Component({
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    animations: [appModuleAnimation()]
})
export class HomeComponent extends PagedListingComponentBase<OrderListDto> implements OnInit {

    @ViewChild('createOrderModal') createOrderModal: CreateOrderComponent;
    @ViewChild('editOrderModal') editOrderModal: EditOrderComponent;
    @ViewChild('downOrderModal') downOrderModal: DownOrderComponent;
    @ViewChild('addOtherdescModal') addOtherdescModal: AddOtherdescComponent;
    @ViewChild('content') content: ElementRef;

    orders: OrderListDto[] = [];
    compolateState = OrderType._5;

    public key = '';
    public orderType = -1;
    public downFrom: moment.Moment = null;
    public downTo: moment.Moment = null;
    public complateFrom: moment.Moment = null;
    public complateTo: moment.Moment = null;
    public AppConsts = AppConsts;
    constructor(
        injector: Injector,
        private _orderServiceProxy: OrderServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        super.ngOnInit();
        $.AdminBSB.autoHeight();
        const _this = this;
        $(this.content.nativeElement).find('.datetimepicker').datetimepicker({
            format: 'yyyy-mm-dd',
            language: 'zh-CN',
            autoclose: true,
            minView: 2
        }).on('changeDate', function (ev) {
            switch (ev.currentTarget.id) {
                case 'downFrom':
                    _this.downFrom = moment(ev.date);
                    break;
                case 'downTo':
                    _this.downTo = moment(ev.date);
                    break;
                case 'complateFrom':
                    _this.complateFrom = moment(ev.date);
                    break;
                case 'complateTo':
                    _this.complateTo = moment(ev.date);
                    break;
            }
            // ev.currentTarget.focus();
            // ev.currentTarget.blur();
            $(ev.currentTarget).trigger('input');
            $(ev.currentTarget).change();
        });
    }

    list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        console.log(this.downFrom);
        this._orderServiceProxy.getOrders(this.key,
            this.orderType,
            this.downFrom,
            this.downTo,
            this.complateFrom,
            this.complateTo,
            request.skipCount,
            request.maxResultCount)
            .pipe(finalize(() => { finishedCallback() }))
            .subscribe((result: PagedResultDtoOfOrderListDto) => {
                this.orders = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    resetSearch(): void {
        this.orderType = -1;
        this.downFrom = null;
        this.downTo = null;
        this.key = '';
        this.complateFrom = null;
        this.complateTo = null;

        $('#downFrom').val('');
        $('#downTo').val('');
        $('#complateFrom').val('');
        $('#complateTo').val('');

        this.refresh();
    }

    createOrder(): void {
        this.createOrderModal.show();
    }
    editOrder(order: OrderListDto): void {
        this.editOrderModal.show(order.id);
    }
    downOrder(order: OrderListDto): void {
        this.downOrderModal.show(order.id);
    }

    delete(): void {

    }

    complate(orderId: number): void {
        const _this = this;
        abp.message.confirm('确定要标记完成吗？订单完成以后不在可以修改！', function (i) {
            if (i) {
                _this._orderServiceProxy.complate(orderId)
                    .subscribe((result) => {
                        _this.refresh();
                    })
            }
        })
    }
}
