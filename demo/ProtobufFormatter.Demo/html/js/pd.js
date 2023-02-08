/*eslint-disable block-scoped-var, id-length, no-control-regex, no-magic-numbers, no-prototype-builtins, no-redeclare, no-shadow, no-var, sort-vars*/
import $protobuf from "./protobufjs/minimal/protobuf.esm.min.js";

const $Reader = $protobuf.Reader,
  $Writer = $protobuf.Writer,
  $util = $protobuf.util;

const $root = $protobuf.roots["default"] || ($protobuf.roots["default"] = {});

export const ProtobufFormatter = ($root.ProtobufFormatter = (() => {
  const ProtobufFormatter = {};

  ProtobufFormatter.Demo = (function () {
    const Demo = {};

    Demo.Models = (function () {
      const Models = {};

      Models.Pd = (function () {
        function Pd(properties) {
          if (properties)
            for (
              let keys = Object.keys(properties), i = 0;
              i < keys.length;
              ++i
            )
              if (properties[keys[i]] != null)
                this[keys[i]] = properties[keys[i]];
        }

        Pd.prototype.id = 0;
        Pd.prototype.name = "";

        Pd.encode = function encode(message, writer) {
          if (!writer) writer = $Writer.create();
          if (message.id != null && Object.hasOwnProperty.call(message, "id"))
            writer.uint32(8).int32(message.id);
          if (
            message.name != null &&
            Object.hasOwnProperty.call(message, "name")
          )
            writer.uint32(18).string(message.name);
          return writer;
        };

        Pd.encodeDelimited = function encodeDelimited(message, writer) {
          return this.encode(message, writer).ldelim();
        };

        Pd.decode = function decode(reader, length) {
          if (!(reader instanceof $Reader)) reader = $Reader.create(reader);
          let end = length === undefined ? reader.len : reader.pos + length,
            message = new $root.ProtobufFormatter.Demo.Models.Pd();
          while (reader.pos < end) {
            let tag = reader.uint32();
            switch (tag >>> 3) {
              case 1: {
                message.id = reader.int32();
                break;
              }
              case 2: {
                message.name = reader.string();
                break;
              }
              default:
                reader.skipType(tag & 7);
                break;
            }
          }
          return message;
        };

        Pd.decodeDelimited = function decodeDelimited(reader) {
          if (!(reader instanceof $Reader)) reader = new $Reader(reader);
          return this.decode(reader, reader.uint32());
        };

        Pd.fromObject = function fromObject(object) {
          if (object instanceof $root.ProtobufFormatter.Demo.Models.Pd)
            return object;
          let message = new $root.ProtobufFormatter.Demo.Models.Pd();
          if (object.id != null) message.id = object.id | 0;
          if (object.name != null) message.name = String(object.name);
          return message;
        };

        Pd.toObject = function toObject(message, options) {
          if (!options) options = {};
          let object = {};
          if (options.defaults) {
            object.id = 0;
            object.name = "";
          }
          if (message.id != null && message.hasOwnProperty("id"))
            object.id = message.id;
          if (message.name != null && message.hasOwnProperty("name"))
            object.name = message.name;
          return object;
        };

        Pd.prototype.toJSON = function toJSON() {
          return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        Pd.getTypeUrl = function getTypeUrl(typeUrlPrefix) {
          if (typeUrlPrefix === undefined) {
            typeUrlPrefix = "type.googleapis.com";
          }
          return typeUrlPrefix + "/ProtobufFormatter.Demo.Models.Pd";
        };

        return Pd;
      })();

      return Models;
    })();

    return Demo;
  })();

  return ProtobufFormatter;
})());

export { $root as default };
