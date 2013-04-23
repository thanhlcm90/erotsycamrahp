//Tạo jMenu, phát triển và fixbug từ DropDownMenu
//Copyright Lê Cao Minh Thành

var mlddm_shiftx = 0;
var mlddm_shifty = 0;
var mlddm_timeout = 500;
var mlddm_effect = 'fade';
var mlddm_orientation = 'h';
var mlddm_direction = 1;
var mlddm_highlight = 1;
var mlddm_md = 375;
var mlddm_closeonclick = 1;
/**/

var _18 = 0;
if (!mlddm_effect) {
    var mlddm_shiftx = 0;
    var mlddm_shifty = 0;
    var mlddm_timeout = 500;
    var mlddm_effect = 'none';
    var mlddm_effect_speed = 300;
    var mlddm_orientation = 'h';
    var mlddm_direction = true;
    var mlddm_delay = 0;
    var mlddm_highlight = true;
    var mlddm_closeonclick = false;
    var mlddm_md = 375
}
var MLDDM_CLASS = 'mlddm';
var obj_menu = new Array();
function mlddminit(md7) {
    var candidates = document.getElementsByTagName('ul');
    var index = 0;
    for (var i = 0; i < candidates.length; i++) {
        if (candidates[i].className == MLDDM_CLASS) {
            candidates[i].style.visibility = 'visible';
            var obj = candidates[i];
            var value = obj.getAttribute('params');
            obj_menu[index] = new menu(obj, index, value);
            index++
        }
    }
}
function layer(handler) {
    this.handler = handler;
    this.showed = false;
    this.level = 0;
    this.x = 0;
    this.y = 0;
    this.xa = 0;
    this.ya = 0;
    this.outerwidth = 0;
    this.outerheight = 0;
    this.innerwidth = 0;
    this.innerheight = 0;
    this.border = 0;
    this.topmargin = 0;
    this.shifter = 0;
    this.parentindex = 0;
    this.reverse = false;
    this.timeouts = new Array();
    this.degree = 0;
    this.button = null;
    this.buttoncss = new Array();
}
function menu(obj, obj_n, params) {
    var _10 = obj;
    var _5 = obj_n;
    var _1 = this;
    var _11 = null;
    var _12 = null;
    var _4 = true;
    var _19 = null;
    var _6 = false;
    var _13 = mlddm_shiftx;
    var _16 = mlddm_shifty;
    var _21 = mlddm_timeout;
    var _7 = mlddm_effect;
    var _2 = mlddm_effect_speed;
    var _8 = mlddm_orientation;
    var _9 = mlddm_direction;
    var _20 = mlddm_delay;
    var _14 = mlddm_highlight;
    var _17 = mlddm_closeonclick;
    var params_array;
    if (params) {
        params_array = params.split(",");
        if (params_array[0])
            _13 = params_array[0] * 1;
        if (params_array[1])
            _16 = params_array[1] * 1;
        if (params_array[2])
            _21 = params_array[2] * 1;
        if (params_array[3])
            _7 = params_array[3];
        if (params_array[4])
            _2 = params_array[4] * 1;
        if (params_array[5])
            _8 = params_array[5];
        if (params_array[6])
            _9 = params_array[6] * 1;
        if (params_array[7])
            _20 = params_array[7] * 1;
        if (params_array[8])
            _14 = params_array[8] * 1;
        if (params_array[8])
            _17 = params_array[9] * 1;
        if (!_2)
            _2 = 1000
    }
    this._0 = new Array();
    function opacity(index, opac_start, opac_end, speed) {
        var current_layer = _1._0[index];
        for (var z = 0; z < current_layer.timeouts.length; z++)
            clearTimeout(current_layer.timeouts[z]);
        var degree = current_layer.degree;
        var speed = Math.round(1000 / speed);
        var timer = 0;
        if (degree < opac_end) {
            for (var i = degree; i <= opac_end; i = i + 4) {
                current_layer.timeouts[timer] = setTimeout("changeOpac(" + _5 + "," + index + "," + i + ")", (timer * speed));
                timer++
            }
        } else if (degree > opac_end) {
            for (var i = degree; i >= opac_end; i = i - 4) {
                current_layer.timeouts[timer] = setTimeout("changeOpac(" + _5 + "," + index + "," + i + ")", (timer * speed));
                timer++
            }
        }
    }
    function slide(index, direction, speed) {
        var current_layer = _1._0[index];
        for (var z = 0; z < current_layer.timeouts.length; z++)
            clearTimeout(current_layer.timeouts[z]);
        var degree = current_layer.degree;
        var speed = Math.round(1000 / speed);
        var timer = 0;
        if (_8 == 'h')
            _15 = 0;
        else
            _15 = 1;
        if (direction == 'show') {
            for (i = degree; i <= 100; i = i + 2) {
                current_layer.timeouts[timer] = setTimeout("changePOS(" + _5 + "," + index + "," + i + "," + _15 + ")", (timer * speed));
                timer++
            }
        } else if (direction == 'hide') {
            for (i = degree; i >= 0; i = i - 2) {
                current_layer.timeouts[timer] = setTimeout("changePOS(" + _5 + "," + index + "," + i + "," + _15 + ")", (timer * speed));
                timer++
            }
        }
    }
    function getlevel(layer) {
        var level = 0;
        var currentobj = layer;
        while (currentobj.className != MLDDM_CLASS) {
            if (currentobj.nodeName == 'UL')
                level++;
            currentobj = currentobj.parentNode
        }
        return level
    }
    function updateglobalstate() {
        _6 = false;
        for (var i = 0; i < _1._0.length; i++)
            if (_1._0[i].showed) {
                _6 = true;
                break
            }
    }
    function mopen(index) {
        if (!_1._0[index].showed && (mlddm_md == 375)) {
            if (_7 == 'fade')
                opacity(index, 0, 100, _2);
            else if (_7 == 'slide')
                slide(index, 'show', _2);
            else
                _1._0[index].handler.style.visibility = 'visible';
            highlight_button(index, true);
            _1._0[index].showed = true;
            _6 = true;
        }
    }
    function mclose(index) {
        if (_1._0[index].showed) {
            if (_7 == 'fade')
                opacity(index, 100, 0, _2);
            else if (_7 == 'slide')
                slide(index, 'hide', _2);
            else
                _1._0[index].handler.style.visibility = 'hidden';
            highlight_button(index, false);
            _1._0[index].showed = false;
        }
        if (_1._0[index].level == 1)
            updateglobalstate()
    }
    function highlight_button(index, activate) {
        var cl = _1._0[index];
        if (activate && _14 && cl.button)
            cl.button.style.cssText = cl.buttoncss[1];
        else if (_14 && cl.button)
            cl.button.style.cssText = cl.buttoncss[0]
    }
    function getlayerindex(obj) {
        for (i = 0; i < _1._0.length; i++) {
            if (_1._0[i].handler == obj)
                return i
        }
        return -1
    }
    function getparentindex(layer) {
        while (layer.className != MLDDM_CLASS) {
            layer = layer.parentNode;
            if (layer.nodeName == 'UL')
                return getlayerindex(layer)
        }
        return -1
    }
    function gettopmargin(obj) {
        var top = obj.offsetTop;
        obj.style.marginTop = '0px';
        var margintop = top - obj.offsetTop;
        obj.style.marginTop = margintop + 'px';
        return margintop
    }
    function getparentheight(obj) {
        while (obj.className != MLDDM_CLASS) {
            obj = obj.parentNode;
            if (obj.nodeName == 'LI')
                break
        }
        return obj.getElementsByTagName("a")[0].offsetHeight;
    }
    function getparentbutton(obj) {
        if (obj.className == MLDDM_CLASS)
            return null;
        while (obj.nodeName != 'LI')
            obj = obj.parentNode;
        return getchildnode(obj, 'A')
    }
    function canceldelay() {
        if (_11) {
            window.clearTimeout(_11);
            _11 = null
        }
    }
    function mclosetime() {
        _12 = window.setTimeout(_1.pcloseall, _21)
    }
    function mcancelclosetime() {
        if (_12) {
            window.clearTimeout(_12);
            _12 = null
        }
    }
    function storebuttoncss() {
        var noin_selector = '.' + MLDDM_CLASS + ' > li > a:hover'.toLowerCase();
        var root_selector = '.' + MLDDM_CLASS + ' li a:hover'.toLowerCase();
        var next_selector = '.' + MLDDM_CLASS + ' ul li a:hover'.toLowerCase();
        var noin_style = '';
        var root_style = '';
        var next_style = '';
        var cssrules = new Array();
        for (var i = 0; i < document.styleSheets.length; i++) {
            try {
                cssrules[cssrules.length] = document.styleSheets[i].cssRules || document.styleSheets[i].rules
            } catch (err) {
            }
        }
        for (var j = 0; j < cssrules.length; j++) {
            if (cssrules[j] != null) {
                for (var k = 0; k < cssrules[j].length; k++) {
                    var rule = cssrules[j][k];
                    if (!rule.selectorText)
                        continue;
                    if (rule.selectorText.toLowerCase() == noin_selector)
                        noin_style = rule.style.cssText;
                    else if (rule.selectorText.toLowerCase() == root_selector)
                        root_style = rule.style.cssText;
                    else if (rule.selectorText.toLowerCase() == next_selector)
                        next_style = rule.style.cssText
                }
            }
        }
        var cl = _1._0;
        for (var z = 0; z < cl.length; z++) {
            if (cl[z].button)
                cl[z].buttoncss[0] = cl[z].button.style.cssText;
            if (cl[z].button && cl[z].level == 1)
                cl[z].buttoncss[1] = root_style + ';' + noin_style;
            if (cl[z].button && cl[z].level > 1)
                cl[z].buttoncss[1] = root_style + ';' + next_style;
        }
    }
    function setpositions(client_width, scroll_left) {
        var max_right = client_width + scroll_left;
        for (var i = 0; i < _1._0.length; i++) {
            if (_1._0[i].level > 1) {
                _1._0[i].handler.style.left = _1._0[i].x + 'px';
                _1._0[i].reverse = false
            }
        }
        for (var i = 0; i < _1._0.length; i++) {
            var current_layer = _1._0[i];
            if (current_layer.level > 1) {
                var layer_width = current_layer.outerwidth;
                var border_width = current_layer.border;
                var layer_absx = findPos(current_layer.handler)[0];
                if ((layer_absx + layer_width + border_width * current_layer.level - border_width) > max_right && _9) {
                    current_layer.handler.style.left = -layer_width - _13 + 'px';
                    current_layer.reverse = true
                }
            }
        }
    }
    this.pmopentime = function (index) {
        if (!_6) {
            _6 = index;
            _11 = setTimeout("openLayer(" + _5 + "," + index + ")", _20)
        } else
            mopen(index)
    };
    this.eventover = function () {
        if (_4) {
            _4 = false;
            mcancelclosetime();
            var currentli = this;
            var layer = currentli.getElementsByTagName("ul")[0];
            var ind = getlayerindex(layer);
            if (ind >= 0)
                _1.pmopentime(ind);
            var open_layers = new Array();
            open_layers[0] = currentli.getElementsByTagName("ul")[0];
            if (!open_layers[0])
                open_layers[0] = 0;
            var currobj = currentli.parentNode;
            var num = 0;
            while (currobj.className != MLDDM_CLASS) {
                if (currobj.nodeName == 'UL') {
                    num++;
                    open_layers[num] = currobj
                }
                currobj = currobj.parentNode
            }
            var layers_to_hide = new Array(_1._0.length);
            for (var i = 0; i < layers_to_hide.length; i++)
                layers_to_hide[i] = false;
            for (var i = 0; i < open_layers.length; i++)
                layers_to_hide[getlayerindex(open_layers[i])] = true;
            for (var i = 0; i < layers_to_hide.length; i++)
                if (!layers_to_hide[i] && (_19 != open_layers[0]))
                    mclose(i);
            _19 = open_layers[1]
        }
    };
    this.eventclick = function () {
        if (getchildnode(this, null).nodeName == 'A') {
            _4 = true;
            _1.pcloseall()
        }
    };
    this.eventout = function () {
        _4 = true
    };
    this.allout = function () {
        mclosetime();
        canceldelay()
    };
    this.allover = function () {
        mcancelclosetime()
    };
    this.eventresize = function () {
        setpositions(getClientWidth(), getScrollLeft())
    };
    this.eventscroll = function () {
        setpositions(getClientWidth(), getScrollLeft())
    };
    this.pcloseall = function () {
        for (var i = 0; i < _1._0.length; i++) {
            if (_4)
                mclose(i)
        }
    };
    if (document.getElementById('debug'))
        _18 = document.getElementById('debug');
    _18.value = '';
    var all_li = _10.getElementsByTagName("li");
    this._0[0] = new layer(_10);
    for (var z = 0; z < all_li.length; z++) {
        var layer_handler = all_li[z].getElementsByTagName("ul")[0];
        if (layer_handler)
            this._0[this._0.length] = new layer(layer_handler);
        all_li[z].onmouseover = this.eventover;
        all_li[z].onmouseout = this.eventout;
        if (_17)
            all_li[z].onclick = this.eventclick
    }
    _10.onmouseout = this.allout;
    _10.onmouseover = this.allover;
    if (_9)
        window.onresize = this.eventresize;
    if (_9)
        window.onscroll = this.eventscroll;
    document.onclick = this.pcloseall;
    for (var num = 1; num < this._0.length; num++) {
        var nodesww = this._0[num].handler.childNodes;
        var nodes = new Array();
        var specific_nodes = new Array();
        var maxwidth = 0;
        for (var x = 0; x < nodesww.length; x++) {
            if (!is_ignorable(nodesww[x]))
                nodes[nodes.length] = nodesww[x]
        }
        for (var y = 0; y < nodes.length; y++) {
            var dnodes = nodes[y].getElementsByTagName("*");
            if (dnodes.length && !is_ignorable(dnodes[0]) && dnodes[0].nodeName != 'A') {
                dnodes[0].style.display = 'none';
                specific_nodes[specific_nodes.length] = dnodes[0]
            }
        }
        for (var z = 0; z < nodes.length; z++) {
            var anodes = nodes[z].getElementsByTagName("a");
            if (anodes[0]) {
                var width = anodes[0].offsetWidth;
                if (width > maxwidth)
                    maxwidth = width
            }
        }
        for (var s = 0; s < specific_nodes.length; s++)
            specific_nodes[s].style.display = 'block';
        this._0[num].handler.style.width = maxwidth + 'px'
    }
    for (var num = 0; num < this._0.length; num++) {
        var cl = this._0[num];
        cl.level = getlevel(cl.handler);
        cl.parentindex = getparentindex(cl.handler);
        cl.outerwidth = cl.handler.offsetWidth;
        cl.outerheight = cl.handler.offsetHeight;
        cl.innerwidth = getchildnode(cl.handler.getElementsByTagName("li")[0], null).offsetWidth;
        cl.innerheight = 0;
        cl.border = (cl.outerwidth - cl.innerwidth) / 2;
        cl.topmargin = gettopmargin(cl.handler);
        cl.shifter = getparentheight(cl.handler);
        cl.button = getparentbutton(cl.handler)
    }
    ;
    for (var num = 0; num < this._0.length; num++) {
        var level = this._0[num].level;
        var cl = this._0[num];
        if ((_8 == 'h' && level > 1) || (_8 == 'v' && level > 0)) {
            cl.x = this._0[cl.parentindex].innerwidth + _13;
            cl.y = cl.handler.offsetTop - cl.topmargin - cl.shifter + _16;
            cl.handler.style.left = cl.x + 'px';
            cl.handler.style.top = cl.y + 'px'
        } else {
            cl.x = cl.handler.offsetLeft;
            cl.y = cl.handler.offsetTop - cl.topmargin
        }
        cl.xa = findPos(cl.handler)[0];
        cl.ya = findPos(cl.handler)[1]
    }
    storebuttoncss();
    setpositions(getClientWidth(), getScrollLeft())
}
function openLayer(obj_num, layer_num) {
    obj_menu[obj_num].pmopentime(layer_num)
}
function changeOpac(obj_num, layer_num, opacity) {
    var object = obj_menu[obj_num];
    var layer = object._0[layer_num];
    layer.degree = opacity;
    layer.handler.style.opacity = (opacity / 100);
    layer.handler.style.MozOpacity = (opacity / 100);
    layer.handler.style.KhtmlOpacity = (opacity / 100);
    layer.handler.style.filter = "alpha(opacity=" + opacity + ")";
    if (opacity > 98)
        layer.handler.style.filter = 'none';
    if (opacity > 0)
        layer.handler.style.visibility = 'visible';
    if (opacity <= 0)
        layer.handler.style.visibility = 'hidden'
}
function changePOS(obj_num, layer_num, pos, ori) {
    var object = obj_menu[obj_num];
    var layer = object._0[layer_num];
    var level = layer.level;
    var xa = layer.xa;
    var ya = layer.ya;
    var width = layer.outerwidth;
    var height = layer.outerheight;
    var margintop = layer.topmargin;
    var reverse = layer.reverse;
    layer.degree = pos;
    var maxclip_w = getClientWidth() - xa;
    var maxclip_h = getClientHeight() - ya;
    if (!reverse) {
        if (level == 1 && ori == 0) {
            var h = height - pos * height / 100;
            uniclip(layer.handler, h, maxclip_w, maxclip_h, 0);
            layer.handler.style.marginTop = -h + margintop + 'px'
        } else {
            var w = width - pos * width / 100;
            uniclip(layer.handler, 0, maxclip_w, maxclip_h, w);
            layer.handler.style.marginLeft = -w + 'px'
        }
    } else {
        var w = width - pos * width / 100;
        var mw = width - w;
        uniclip(layer.handler, 0, mw, maxclip_h, 0);
        layer.handler.style.marginLeft = w + 'px'
    }
    if (pos <= 0) {
        layer.handler.style.visibility = 'hidden';
        uniclip(layer.handler, 0, 0, 0, 0);
        layer.handler.style.marginLeft = 'auto';
    }
    if (pos > 0) {
        layer.handler.style.visibility = 'visible';
    }
    if (pos > 98) {
        uniclip(layer.handler, 0, 0, 0, 0);
        layer.handler.style.marginLeft = 'auto';
    }
}
function is_all_ws(nod) {
    return !(/[^\t\n\r ]/.test(nod.data))
}
function is_ignorable(nod) {
    return (nod.nodeType == 8) || ((nod.nodeType == 3) && is_all_ws(nod))
}
function node_after(sib) {
    while ((sib = sib.nextSibling)) {
        if (!is_ignorable(sib))
            return sib
    }
    return null
}
function getchildnode(handler, nodename) {
    var node = handler.childNodes[0];
    try {
        while (node.nodeName != nodename) {
            if (!is_ignorable(node) && !nodename)
                break;
            node = node_after(node)
        }
        return node
    } catch (err) {
        return null
    }
}
function uniclip(handler, x1, y1, x2, y2) {
    if ((x1 == 0) && (y1 == 0) && (x2 == 0) && (y2 == 0)) {
        var csstext = handler.style.cssText;
        handler.style.cssText = csstext.replace(/clip: {0,2}.*\);{0,1}/i, '');
        return
    }
    handler.style.clip = 'rect(' + x1 + 'px, ' + y1 + 'px, ' + x2 + 'px, ' + y2 + 'px)'
}
function getClientWidth() {
    return document.documentElement.clientWidth
}
function getClientHeight() {
    return document.documentElement.clientHeight
}
function getScrollLeft() {
    return document.documentElement.scrollLeft
}
function findPos(obj) {
    var curleft = curtop = 0;
    if (obj.offsetParent) {
        do {
            curleft += obj.offsetLeft;
            curtop += obj.offsetTop
        } while (obj = obj.offsetParent)
    }
    return [curleft, curtop]
}
_3 = Array();
function callAllLoaders() {
    var i, loaderFunc;
    for (i = 0; i < _3.length; i++) {
        loaderFunc = _3[i];
        if (loaderFunc != callAllLoaders)
            loaderFunc()
    }
}
function appendLoader(loaderFunc) {
    if (window.onload && window.onload != callAllLoaders)
        _3[_3.length] = window.onload;
    window.onload = callAllLoaders;
    _3[_3.length] = loaderFunc
}
appendLoader(mlddminit);
function mlddminit2(md7) {
    debugger;
    var candidates = document.getElementsByTagName("ul");
    var index = 0;
    for (var i = 0; i < candidates.length; i++) {
        if (candidates[i].className == MLDDM_CLASS) {
            candidates[i].style.visibility = "visible";
            var obj = candidates[i];
            var value = obj.getAttribute("params");
            obj_menu[index] = new menu(obj, index, value);
            index++;
        }
    }
}
